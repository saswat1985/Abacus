using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;



namespace EDIConvertorExecutable
{
    public class Utility
    {
        public static int GetPageCount(int rowCount, int pageSize)
        {
            int returnResult = 0;
            if (rowCount % pageSize > 0)
            {
                int result = Convert.ToInt32(rowCount / pageSize);
                returnResult = result + 1;
            }
            else
            {
                returnResult = Convert.ToInt32(rowCount / pageSize);
            }
            return returnResult;


        }

        public static void CreateMissingDirectory(string path)
        {
            try
            {
                bool folderExists = Directory.Exists(path);
                if (!folderExists)
                    Directory.CreateDirectory(path);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string DoubleDateTime()
        {
            return DateTime.Now.Day.TrimString() + DateTime.Now.Month.TrimString() + DateTime.Now.Year.TrimString();
        }

        public static string PrepareDirectory(string childFolderName)
        {
            try
            {
                string path = AppKeyCollection.ImageFolderName;
                string folderPath = Path.GetDirectoryName(AppKeyCollection.AppRootFolder) + "\\" + path + "\\" + Utility.DoubleDateTime() + "\\" + childFolderName;
                CreateMissingDirectory(folderPath);
                return folderPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenrateHTML(DataTable dtrecord, int? imageType)
        {
            try
            {
                if (imageType == 1)
                {
                    return GetNonBorderString(dtrecord);
                }
                else
                {
                    return GetBorderString(dtrecord);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private static string GetBorderString(DataTable dtrecord)
        {
            try
            {
                StringBuilder htmlString = new StringBuilder();
               // htmlString.Append("<div style='padding-right:50px;'>");
                htmlString.Append("<table style='width: 1600px; font-family: " + AppKeyCollection.FontStyle + ";font-size: " + AppKeyCollection.FontSize + "px; margin-top: 17px;margin-bottom: 10px;table-layout: fixed;'>");
                for (int i = 0; i < dtrecord.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        htmlString.Append("<tr>");
                    }
                    htmlString.Append("<td style='width:750px;border-style: solid; border-width: thick;border-color: black;padding-left: 10px;padding-right: 10px;word-wrap:break-word;'>");
                    for (int j = 0; j < dtrecord.Columns.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(dtrecord.Rows[i][j].TrimString()))
                        {
                            htmlString.Append(dtrecord.Rows[i][j].TrimString() + "&nbsp;");
                        }

                    }

                    htmlString.Append("</td>");
                    if (i % 2 != 0 || (i + 1) == dtrecord.Rows.Count)
                    {
                        htmlString.Append("</tr>");
                    }

                }
                htmlString.Append("</table>");
                //htmlString.Append("</div>");
                return htmlString.TrimString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetNonBorderString(DataTable dtrecord)
        {
            StringBuilder htmlString = new StringBuilder();
            foreach (DataRow item in dtrecord.Rows)
            {
                foreach (var val in item.ItemArray)
                {
                    htmlString.Append(val + "\t");
                }
                htmlString.Append("\n\n");

            }

            return htmlString.TrimString();
        }

        public static Image TextToImage(string txt, Font fontname, Color bgcolor, Color fcolor, int? imageType)
        {
            try
            {
                Image returnImage = null;
                switch (imageType)
                {
                    case 1:
                        {
                            returnImage = ConvertTextToImage(txt, fontname, bgcolor, fcolor);
                            break;
                        }
                    case 2:
                        {
                            returnImage = ConvertHTMLToImage(txt);
                            break;
                        }
                    default:
                        break;
                }
                return returnImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Image ConvertHTMLToImage(string htmltext)
        {
            try
            {
                float x = 100.0F;
                float y = 100.0F;
                PointF pointf = new PointF(x, y);
                float width = 1600.0F;
                float height = 2750.0F;
                SizeF size = new SizeF(width, height);

                Image imgReturn = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(htmltext, new Size(1950, 1650), Color.White);
                //Image imgReturn = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(htmltext, pointf,size,null);

                return imgReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static Image ConvertTextToImage(string txt, Font fontname, Color bgcolor, Color fcolor)
        {
            try
            {
                ////first, create a dummy bitmap just to get a graphics object
                Image img = new Bitmap(1, 1);
                Graphics drawing = Graphics.FromImage(img);

                //measure the string to see how big the image needs to be
                SizeF textSize = drawing.MeasureString(txt, fontname);

                //free up the dummy image and old graphics object
                img.Dispose();
                drawing.Dispose();

                //create a new image of the right size
                img = new Bitmap(1700, 2808);

                drawing = Graphics.FromImage(img);

                //paint the background
                drawing.Clear(bgcolor);

                //create a brush for the text
                Brush textBrush = new SolidBrush(fcolor);
                float x = 100.0F;
                float y = 100.0F;
                float width = 1600.0F;
                float height = 2750.0F;
                RectangleF drawRect = new RectangleF(x, y, width, height);

                // Set format of string.
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                drawing.DrawString(txt, fontname, textBrush, drawRect);

                drawing.Save();

                textBrush.Dispose();
                drawing.Dispose();

                return img;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static bool TrasferFile(string strSourcePath, string strDestinationPath)
        {
            try
            {
                string filename = Path.GetFileName(strSourcePath);
                if (File.Exists(strSourcePath))
                {
                    if (File.Exists(strDestinationPath + "\\" + filename))
                    {
                        File.Delete(strDestinationPath + "\\" + filename);
                    }
                    File.Move(strSourcePath, strDestinationPath + "\\" + filename);

                    return true;
                }
                else
                {
                    //lblMsg.Text ="File does not exist!!!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
