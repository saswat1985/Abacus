using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EntityRefObject;

namespace DataObject
{
    public class BulkDataUpload
    {
        private string sqlConStr = string.Empty;

        public BulkDataUpload()
        {
            sqlConStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(sqlConStr);
        }

        private void SqlBulkDataCopy(DataTable dt)
        {
            SqlConnection sqlCon = GetSqlConnection();
            //creating object of SqlBulkCopy      
            SqlBulkCopy objbulk = new SqlBulkCopy(sqlCon);
            //assigning Destination table name      
            objbulk.DestinationTableName = "ExportDataDetail";
            //Mapping Table column  
            objbulk.ColumnMappings.Add("masterId", "masterId");
            objbulk.ColumnMappings.Add("recordnumber", "recordnumber");
            objbulk.ColumnMappings.Add("customername", "customername");
            objbulk.ColumnMappings.Add("email", "email");
            objbulk.ColumnMappings.Add("resaddress", "resaddress");
            objbulk.ColumnMappings.Add("city1", "city1");
            objbulk.ColumnMappings.Add("state1", "state1");
            objbulk.ColumnMappings.Add("zip1", "zip1");
            objbulk.ColumnMappings.Add("phonenumber1", "phonenumber1");
            objbulk.ColumnMappings.Add("country1", "country1");
            if (dt.Columns.Contains("UPPER"))
                objbulk.ColumnMappings.Add("UPPER", "UPPER");
            objbulk.ColumnMappings.Add("sex1", "sex1");
            objbulk.ColumnMappings.Add("dbirth1", "dbirth1");
            objbulk.ColumnMappings.Add("height", "height");
            objbulk.ColumnMappings.Add("weight", "weight");
            objbulk.ColumnMappings.Add("bloodgroup", "bloodgroup");
            objbulk.ColumnMappings.Add("billingname", "billingname");
            objbulk.ColumnMappings.Add("shippername", "shippername");
            objbulk.ColumnMappings.Add("city2", "city2");
            objbulk.ColumnMappings.Add("zip2", "zip2");
            objbulk.ColumnMappings.Add("state2", "state2");
            objbulk.ColumnMappings.Add("country2", "country2");
            if (dt.Columns.Contains("LOWER"))
                objbulk.ColumnMappings.Add("LOWER", "LOWER");
            objbulk.ColumnMappings.Add("phone2", "phone2");
            objbulk.ColumnMappings.Add("alcoholic", "alcoholic");
            objbulk.ColumnMappings.Add("smoker", "smoker");
            objbulk.ColumnMappings.Add("pastsurg", "pastsurg");
            objbulk.ColumnMappings.Add("diabetic", "diabetic");
            objbulk.ColumnMappings.Add("allergiesd", "allergiesd");
            objbulk.ColumnMappings.Add("policy", "policy");
            objbulk.ColumnMappings.Add("lifeassure", "lifeassure");
            objbulk.ColumnMappings.Add("pinst", "pinst");
            objbulk.ColumnMappings.Add("pholder", "pholder");
            objbulk.ColumnMappings.Add("stmname", "stmname");
            objbulk.ColumnMappings.Add("stmcode", "stmcode");
            objbulk.ColumnMappings.Add("dob", "dob");
            objbulk.ColumnMappings.Add("sex2", "sex2");
            objbulk.ColumnMappings.Add("cardname", "cardname");
            objbulk.ColumnMappings.Add("medicine", "medicine");
            objbulk.ColumnMappings.Add("dosage", "dosage");
            objbulk.ColumnMappings.Add("tablets", "tablets");
            objbulk.ColumnMappings.Add("pillrate", "pillrate");
            objbulk.ColumnMappings.Add("cost", "cost");
            objbulk.ColumnMappings.Add("shippingcost", "shippingcost");
            objbulk.ColumnMappings.Add("total", "total");
            objbulk.ColumnMappings.Add("remark", "remark");
            if (dt.Columns.Contains("Value1"))
                objbulk.ColumnMappings.Add("Value1", "value1");
            if (dt.Columns.Contains("Value2"))
                objbulk.ColumnMappings.Add("Value2", "value2");
            if (dt.Columns.Contains("Value3"))
                objbulk.ColumnMappings.Add("Value3", "value3");




            //inserting Datatable Records to DataBase                 
            sqlCon.Open();
            objbulk.WriteToServer(dt);
            sqlCon.Close();
            dt.Dispose();
            // MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);  

        }

        public int SqlBulkDataCopyMaster(DataTable dtData, MstExportData objMasterdata)
        {
            try
            {
                ClsDALSqlDataAccessLayer objSql = new ClsDALSqlDataAccessLayer();
                SqlParameter[] param = 
                { 
                  new SqlParameter("@Type","INSERTMASTERDATA"),
                  new SqlParameter("@FileCode",objMasterdata.FileCode),                  
                  new SqlParameter("@UploadBy",objMasterdata.UploadBy),
                  new SqlParameter("@UploadPath",objMasterdata.UploadPath),
                  new SqlParameter("@ImageType",objMasterdata.ImageType),
                  new SqlParameter("@RecordId",objMasterdata.RecordId)
                 
                };
                param[5].Direction = ParameterDirection.Output;
                int result = objSql.ExecuteNonQuery(CommandType.StoredProcedure, "USP_ExportDataMaster", param);
                objMasterdata.RecordId = Convert.ToInt32(param[5].Value);

                DataColumn newCol = new DataColumn("masterid", typeof(System.Int32));
                newCol.DefaultValue = objMasterdata.RecordId;
                dtData.Columns.Add(newCol);
                SqlBulkDataCopy(dtData);

                return objMasterdata.RecordId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddImageConvertRecord(ExportToImage objExportImage)
        {
            try
            {
                using (ImageDataDBEntities objdb = new ImageDataDBEntities())
                {
                    objdb.AddToExportToImages(objExportImage);
                    objdb.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetConvertRecords()
        {
            try
            {
                ClsDALSqlDataAccessLayer objSql = new ClsDALSqlDataAccessLayer();
                SqlParameter[] param = 
                { 
                  new SqlParameter("@Type","GETConvertData")
                };
                return objSql.ExecuteDataset(CommandType.StoredProcedure, "USP_ExportDataMaster", param).Tables[0];
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
                ClsDALSqlDataAccessLayer objSql = new ClsDALSqlDataAccessLayer();
                SqlParameter[] param = 
                { 
                  
                  new SqlParameter("@masterId",uploadId),
                  new SqlParameter("@RecsPerPage",pageSize),
                  new SqlParameter("@Page",pageNo),
                };

                return objSql.ExecuteDataset(CommandType.StoredProcedure, "proc_Paging_CTE", param).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<ExportDataMaster> GetExportDataPendingConversion()
        {
            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    return dbx.ExportDataMasters.Where(k => k.IsConverted == false).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetChildCount(int masterId)
        {
            int result = 0;
            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    var resultCount = from m in dbx.ExportDataDetails
                                      where m.masterId == masterId
                                      select m;
                    result = resultCount.Count();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUploadStatus(ExportToImage objExportInfo)
        {
            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    objDB.AddToExportToImages(objExportInfo);
                    objDB.SaveChanges();

                    ExportDataMaster objmaster = objDB.ExportDataMasters.Where(p => p.Id == objExportInfo.RefrenceId).FirstOrDefault();
                    if (objmaster != null)
                    {
                        objmaster.IsConverted = true;
                        // objDB.AddToExportDataMasters(objmaster);
                        objDB.SaveChanges();
                    }

                    return true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
