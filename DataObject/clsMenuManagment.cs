using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataObject
{
    public class clsMenuManagment : ClsBaseDAL
    {
        ClsDALSqlDataAccessLayer objSql = new ClsDALSqlDataAccessLayer();

        public DataTable GetMainMenuTable(string strUserName)
        {
            try
            {
                DataSet ds = new DataSet();
                //Getting menu from proc uspMenuMaster
                SqlParameter[] sqlParam ={ new SqlParameter("@CreatedBy", strUserName),
                                   new SqlParameter("@Type","BIND_MENU_CONTROL"),
                                   //new SqlParameter("@ApplicationID",ApplicationID)
                                     };
                ds = objSql.ExecuteDataset(CommandType.StoredProcedure, "uspMenuMaster", sqlParam);
                sqlParam = null;
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }


        }

        public string GetNavigationURL(int intMenuItemValue)
        {
            try
            {
                SqlParameter sqlParam = new SqlParameter("@MenuItemId", intMenuItemValue);
                return (string)objSql.ExecuteScalar(CommandType.Text, "Select IsNull(NavigateURL,'') from MstMenuMaster where MenuId=@MenuItemId", sqlParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }
    }
}
