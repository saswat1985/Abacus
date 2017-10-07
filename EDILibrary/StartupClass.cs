using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObject;
using WebsitesScreenshot;
using System.Threading.Tasks;
using System.Diagnostics;
using Ionic.Zip;
using System.IO;
using System.Drawing;

namespace EDIConvertorExecutable
{
    public class StartupClass
    {
        DataObjectExtension objDal = null;

        public void Start()
        {
            try
            {
                int pageNo = 0, pageSize = 0, threadSize = 0;
                string filePath = string.Empty;

                objDal = new DataObjectExtension();
                Font f = new Font(AppKeyCollection.FontStyle, AppKeyCollection.FontSize);
                List<ExportDataMaster> objPendingFiles = objDal.GetPendingExcelToConvert();
                if (objPendingFiles != null && objPendingFiles.Count > 0)
                {
                    foreach (ExportDataMaster item in objPendingFiles)
                    {
                        if (!(bool)item.IsConverted)
                        {
                            if (item.ImageType == 1)
                            {
                                pageSize = Convert.ToInt32(AppKeyCollection.ImageRecordSize);
                                threadSize = AppKeyCollection.Maxthread;
                            }
                            else
                            {
                                pageSize = Convert.ToInt32(AppKeyCollection.RecordBorderImageSize);
                                threadSize = AppKeyCollection.MaxthreadBorderImage;
                            }


                            int recordCount = objDal.GetChildRecordCount(item.Id);
                            pageNo = Utility.GetPageCount(recordCount, pageSize);
                            ParallelOptions objThreadOption = new ParallelOptions();
                            objThreadOption.MaxDegreeOfParallelism = threadSize;
                            Parallel.For(1, pageNo + 1, objThreadOption, i =>
                            {
                                if (item.ImageType != null)
                                {
                                    string fileName = item.FileCode + "_" + item.Id + "_" + i;
                                    string txtContent = Utility.GenrateHTML(objDal.GetExcelRecordPageWise(pageSize, item.Id, i), item.ImageType);

                                    Image image = Utility.TextToImage(txtContent, f, Color.White, Color.Black, item.ImageType);
                                    if (image != null)
                                    {
                                        filePath = SaveImage(image, item.FileCode, fileName);
                                        //filePath = Utility GenerateImage(html, item.FileCode, fileName);
                                        //ErrorLogExtension.TraceLog("In Loop Image creation of file code:" + item.FileCode + "--" + i);
                                        Console.WriteLine("In Loop Image creation of file code:" + item.FileCode + "--" + i);
                                    }
                                }
                            });

                            string zipFileSource = GenerateZipFile(filePath, item.FileCode);
                            Utility.TrasferFile(zipFileSource, AppKeyCollection.MoveZipFile);
                            ErrorLogExtension.TraceLog("Transfer has been complete");
                            //Console.WriteLine("Transfer has been complete");

                            ExportToImage objImage = new ExportToImage() { RefrenceId = item.Id, ConvertFilepath = Path.Combine(AppKeyCollection.MoveZipFile, item.FileCode + ".zip"), ConvertDate = DateTime.Now, ConvertBy = 0 };
                            objDal.UpdateUploadStatus(objImage);

                        }
                    }
                }
                else
                {
                    ErrorLogExtension.TraceLog("No file for conversion");
                    Console.WriteLine("No file for conversion");
                }
            }
            catch (Exception ex)
            {
                ErrorLogExtension.ErrorLog(ex);
            }

        }


        private string SaveImage(Image img, string fileCode, string fileName)
        {
            string filePath = string.Empty;
            try
            {
                filePath = Utility.PrepareDirectory(fileCode);

                img.Save(filePath + "\\" + fileName + ".jpg");

                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        private string GenerateZipFile(string folderPath, string zipFilename)
        {
            string zipFilePath = string.Empty;
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    string[] fileArray = Directory.GetFiles(folderPath, "*.jpg");
                    foreach (var item in fileArray)
                    {
                        zip.AddFile(item, zipFilename);
                    }
                    ErrorLogExtension.TraceLog(string.Format("File {0} Zip Start", zipFilename));
                    zipFilePath = folderPath + "\\" + "" + zipFilename + ".zip";
                    zip.Save(zipFilePath);
                    ErrorLogExtension.TraceLog("Zip End");
                    //Console.WriteLine("Zip End");

                }
                return zipFilePath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
