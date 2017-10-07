using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObject;
using System.Data;

namespace EDIConvertorExecutable
{
    public class DataObjectExtension
    {
        BulkDataUpload objDAL = new BulkDataUpload();

        public List<ExportDataMaster> GetPendingExcelToConvert()
        {
            try
            {
                return objDAL.GetExportDataPendingConversion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetChildRecordCount(int masterId)
        {
            try
            {
                return objDAL.GetChildCount(masterId);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable GetExcelRecordPageWise(int pageSize, int uploadId, int pageNo)
        {
            try
            {
                return objDAL.GetExcelRecordPageWise(pageSize, uploadId, pageNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUploadStatus(ExportToImage objImage)
        {
            try
            {
                objDAL.UpdateUploadStatus(objImage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
