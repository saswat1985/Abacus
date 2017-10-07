using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class clsIPMaster : ClsBaseDAL
    {
        public List<tblIPMaster> GetIPList()
        {
            try
            {
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    return objDB.tblIPMasters.Where(k => k.IsActive == true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveUpdateIPDetail(tblIPMaster objtblIPMaster)
        {
            try
            {
                bool result = false;
                using (ImageDataDBEntities objDB = new ImageDataDBEntities())
                {
                    var ipEntity = objDB.tblIPMasters.Where(o => o.IPAddress == objtblIPMaster.IPAddress).FirstOrDefault();
                    if (ipEntity != null)
                    { 
                        ipEntity.IPAddress = objtblIPMaster.IPAddress;
                        objDB.SaveChanges();
                    }
                    else
                    {
                        objDB.AddTotblIPMasters(objtblIPMaster);                        
                        objDB.SaveChanges();
                    }
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
