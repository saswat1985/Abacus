using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DataObject
{
    public class clsUserLogin : ClsBaseDAL
    {
        ClsDALSqlDataAccessLayer _objSql = new ClsDALSqlDataAccessLayer();

        public tblMstUserMaster FnCheckLogin(tblMstUserMaster _objVal)
        {
            int Result = 0;
            try
            {
                SqlParameter[] sqlParam =
                {
                    new SqlParameter("@Type",_objVal.Type),
                    new SqlParameter("@UserName",_objVal.UserName),
                    new SqlParameter("@Password",_objVal.Password),
                    new SqlParameter("@UserID",SqlDbType.Int),
                    new SqlParameter("@RoleID",SqlDbType.Int),
                    new SqlParameter("@OutRes",SqlDbType.Int),
                    new SqlParameter("@CultureID",SqlDbType.NVarChar,180),
                
                };
                sqlParam[3].Direction = ParameterDirection.Output;
                sqlParam[4].Direction = ParameterDirection.Output;
                sqlParam[5].Direction = ParameterDirection.Output;
                sqlParam[6].Direction = ParameterDirection.Output;

                //sqlParam[1].Direction = ParameterDirection.ReturnValue;
                Result = _objSql.ExecuteNonQuery(CommandType.StoredProcedure, tblMstUserMaster.SPName, sqlParam);

                _objVal.UserCulture = sqlParam[6].Value.TrimString();
                _objVal.OutRes = int.Parse(sqlParam[5].Value.TrimString());
                _objVal.UserId = int.Parse(sqlParam[3].Value.TrimString());
                _objVal.RoleId = int.Parse(sqlParam[4].Value.TrimString());

                return _objVal;
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

        public void InsertUpdateUserLoginDetail(tblMstUserLoginDetail objUserLoginDetail)
        {
            try
            {
                using (ImageDataDBEntities edx = new ImageDataDBEntities())
                {
                    if (objUserLoginDetail != null)
                    {
                        var userLogindetail = edx.tblMstUserLoginDetails.Where(o => o.AuthId == objUserLoginDetail.AuthId).FirstOrDefault();
                        if (userLogindetail != null)
                        {
                            userLogindetail.LogoutTime = objUserLoginDetail.LogoutTime;
                            edx.SaveChanges();
                        }
                        else
                        {
                            tblMstUserLoginDetail objLogIntoSave = new tblMstUserLoginDetail();
                            objLogIntoSave.UserId = objUserLoginDetail.UserId;
                            objLogIntoSave.AuthId = objUserLoginDetail.AuthId;
                            objLogIntoSave.BrowserType = objUserLoginDetail.BrowserType;
                            objLogIntoSave.IPAddress = objUserLoginDetail.IPAddress;
                            objLogIntoSave.CityName = objUserLoginDetail.CityName;
                            objLogIntoSave.Latitude = objUserLoginDetail.Latitude;
                            objLogIntoSave.Longitude = objUserLoginDetail.Longitude;
                            objLogIntoSave.LoginTime = objUserLoginDetail.LoginTime;
                            //objLogIntoSave.LogoutTime = objUserLoginDetail.LogoutTime;
                            edx.AddTotblMstUserLoginDetails(objLogIntoSave);
                            //edx.tblMstUserLoginDetails.Add(objLogIntoSave);
                            edx.SaveChanges();
                        }

                    }

                }
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

        public bool ChangePassowrd(tblMstUserMaster _objVal)
        {
            try
            {
                bool result = false;
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    if (_objVal != null)
                    {
                        var userDetail = objDB.tblMstUserMasters.Where(k => k.UserId == _objVal.UserId).FirstOrDefault();
                        if (userDetail != null)
                        {
                            userDetail.Password = _objVal.Password;
                            objDB.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }

    public class ClsBaseDAL
    {
        public void Dispose()
        {
            try { GC.SuppressFinalize(this); }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
