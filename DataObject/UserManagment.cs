using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class UserManagment
    {
        private string GetUserCode()
        {
            string userCode = string.Empty;
            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    var max = objDB.tblMstUserMasters.DefaultIfEmpty().Max(r => r == null ? 0 : r.UserId) + 1;
                    userCode = "USR-" + max;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userCode;
        }

        public List<tblIPMaster> GetIPList()
        {
            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    return objDB.tblIPMasters.Where(i => i.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MstLanguage> GetLangualeList()
        {
            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    return objDB.MstLanguages.Where(i => i.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<aspnet_Roles> GetUserRoles()
        {
            try
            {
                using (ImageDataDBEntities objdb = new ImageDataDBEntities())
                {
                    return objdb.aspnet_Roles.Where(k => k.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveUpdateUser(tblMstUserMaster objMaster, tblMstUserDetail objDetail, out string userCode)
        {
            bool result = false;
            userCode = string.Empty;

            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    var userMaster = objDB.tblMstUserMasters.Where(k => k.UserId == objMaster.UserId).FirstOrDefault();
                    if (userMaster != null)
                    {
                        var userDetail = objDB.tblMstUserDetails.Where(j => j.UserId == objDetail.UserId).FirstOrDefault();
                        userMaster.UserName = objMaster.UserName;
                        userMaster.Language = objMaster.Language;
                        userMaster.UserEntryId = objMaster.UserEntryId;
                        userMaster.UserEffectedDate = objMaster.UserEffectedDate;

                        userDetail.FirstName = objDetail.FirstName;
                        userDetail.LastName = objDetail.LastName;
                        userDetail.IPAllowed = objDetail.IPAllowed;
                        userDetail.UserEntryDate = objDetail.UserEntryDate;
                        userDetail.EmailId = objDetail.EmailId;

                        objDB.SaveChanges();

                    }
                    else
                    {
                        userCode = objMaster.UserCode = GetUserCode();
                        objDB.AddTotblMstUserMasters(objMaster);
                        objDB.SaveChanges();

                        objDetail.UserId = objMaster.UserId;
                        objDB.AddTotblMstUserDetails(objDetail);
                        objDB.AddToaspnet_UsersInRoles(new aspnet_UsersInRoles() { UserId = objMaster.UserId, RoleId = objMaster.RoleId, UserEntryID = objMaster.UserEntryId, UserEntryDate = DateTime.Now });
                        objDB.SaveChanges();
                    }
                    // objDB.SaveChanges();
                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool IsEmailIDExist(string emailId, int m_Userid)
        {
            Boolean result = false;
            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    if (m_Userid == 0)
                    {
                        tblMstUserDetail objMember = dbx.tblMstUserDetails.Where(o => o.EmailId == emailId).FirstOrDefault();
                        if (objMember != null)
                            result = true;

                    }
                    else
                    {
                        tblMstUserDetail objMember = dbx.tblMstUserDetails.Where(o => o.EmailId == emailId && o.UserId != m_Userid).FirstOrDefault();
                        if (objMember != null)
                            result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool IsUserNameExist(string userName, int m_Userid)
        {
            Boolean result = false;

            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    if (m_Userid == 0)
                    {
                        var objMember = dbx.tblMstUserMasters.Where(o => o.UserName == userName).FirstOrDefault();
                        if (objMember != null)
                            result = true;

                    }
                    else
                    {
                        var objMember = dbx.tblMstUserMasters.Where(o => o.UserName == userName && o.UserId != m_Userid).FirstOrDefault();
                        if (objMember != null)
                            result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string GetUserPassword(string userName)
        {
            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    return dbx.tblMstUserMasters.Where(o => o.UserName ==userName).FirstOrDefault().Password;
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public string GetUserIPAddress(int userId)
        {
            try
            {
                using (ImageDataDBEntities dbx = new ImageDataDBEntities())
                {
                    var queryResult = (from UR in dbx.tblIPMasters
                                       join R in dbx.tblMstUserDetails on UR.Id equals R.IPAllowed
                                       where R.UserId == userId
                                       select new
                                       {
                                           UR.IPAddress,

                                       }).ToList().FirstOrDefault();

                    return queryResult.IPAddress;
                }

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
