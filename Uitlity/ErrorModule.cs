using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;

namespace Uitlity
{
    public class ErrorModule
    {
        public enum enuErrorWarrning
        {
            ErrorInStoreProc = -1,
            StoreProcExecuteSuccessfully = 0,
            AddRecord = 1,
            ActiveStatusChange = 2,
            DulplicateRecord = 3,
            PermissionDenied = 4,
            LoginExpired = 5,
            RecordDelete = 6,
            RecordUpdated = 7,
            AreYouSureDelete = 8,
            ActivateStatusNotChange = 9,
            RecordNotFound = 10,
            RecordFound = 11,
            UnableToUpdateDueToRelation = 12,
            InvalidUserIdAndPassword = 13,
            ApplicationError = 14,
            AccountLocked = 15,
            other = 99,
            MailFiled = 16,
            MailSuccess = 17

        }
        public enum enuMessageType
        {
            Other = 0,
            Error = 1,
            Warrning = 2,
            UserMessage = 3

        }
        #region Error Module
        public static string getErrorWarrning(enuErrorWarrning objErrorWarrning)
        {

            string strReturnMessage = "";

            switch (objErrorWarrning)
            {
                case enuErrorWarrning.MailFiled:
                    {
                        strReturnMessage = "Mail failed on sending to next level!";
                        break;
                    }
                case enuErrorWarrning.MailSuccess:
                    {
                        strReturnMessage = "Mail sent to next level successfully !";
                        break;
                    }

            }
            return strReturnMessage;

        }
        #endregion Error Module
        #region Error Module
        public static string getErrorWarrning(enuErrorWarrning objErrorWarrning, enuMessageType objMessageType, bool IsOverWriteMsg, string strMessage)
        {

            string strReturnMessage = "";
            string consErrorImage = Convert.ToString(ConfigurationSettings.AppSettings["ErrorImage"]);
            string consWarrImage = Convert.ToString(ConfigurationSettings.AppSettings["WarrImage"]);
            string consUserMessageImage = Convert.ToString(ConfigurationSettings.AppSettings["UserMessage"]);
            switch (objErrorWarrning)
            {
                case enuErrorWarrning.ErrorInStoreProc:
                    {
                        strReturnMessage = "Unable to perform operation, please try later";
                        break;
                    }
                case enuErrorWarrning.StoreProcExecuteSuccessfully:
                    {
                        strReturnMessage = "Stored procedure executed successfully";
                        break;

                    }
                case enuErrorWarrning.AddRecord:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Record has been added successfully";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.ApplicationError:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Due to server problem, operation can't be performed";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.AreYouSureDelete:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Are you sure, you want to delete ?";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.DulplicateRecord:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Duplicate record has been found";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.LoginExpired:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Your Login has expired";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.PermissionDenied:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Access denied!";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.RecordDelete:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Record has been deleted successfully";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.RecordUpdated:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Record has been modified successfully";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.ActiveStatusChange:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Active Status has been changed successfully";
                        else
                            strReturnMessage = strMessage;
                        break;

                    }
                case enuErrorWarrning.ActivateStatusNotChange:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Cannot be deactivated, being used in another master.";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }
                case enuErrorWarrning.RecordNotFound:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Record not found";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }
                case enuErrorWarrning.RecordFound:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Record found";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }
                case enuErrorWarrning.UnableToUpdateDueToRelation:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Cannot be deactivated, being used by another table ";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }
                case enuErrorWarrning.InvalidUserIdAndPassword:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Invalid User Id or Password.";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }
                case enuErrorWarrning.AccountLocked:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Your account is locked. Please contact Administrator for unlocking the a/c.";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }

                case enuErrorWarrning.other:
                    {
                        if (IsOverWriteMsg == false)
                            strReturnMessage = "Communication failure";
                        else
                            strReturnMessage = strMessage;
                        break;
                    }

            }
            if (objMessageType == enuMessageType.Error)
                return "<img src='" + consErrorImage + "'>" + " " + strReturnMessage;
            else if (objMessageType == enuMessageType.Warrning)
                return "<img src='" + consWarrImage + "'>" + " " + strReturnMessage;
            else if (objMessageType == enuMessageType.UserMessage)
                return "<img src='" + consUserMessageImage + "'>" + " " + strReturnMessage;
            else
                return strReturnMessage;

        }
        #endregion Error Module
        #region Wrting Error to File
        //Writing Error to ErrorLog folder 
        public static void WriteErrorErrFile(string strCurrentUrl, string strErrMsg)
        {
            string strFilePath = "";
            strFilePath = HttpContext.Current.Server.MapPath(@"~\") + "ErrorLog\\Errorlog " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(@"~\\") + "ErrorLog"))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\\") + "ErrorLog");
            }
            StreamWriter sw = new StreamWriter(strFilePath, true);
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(strErrMsg);
            sw.Flush();
            sw.Close();
        }

        public static void WriteErrorErrFile(string strErrMsg, string filepath, bool webRequest)
        {
            string strFilePath = "";
            if (webRequest)
            {
                strFilePath = HttpContext.Current.Server.MapPath(@"~\") + "ErrorLog\\Errorlog " + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(@"~\\") + "ErrorLog"))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"~\\") + "ErrorLog");
                }
            }
            else
            {
                strFilePath = filepath + "\\" + "Errorlog" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
            }


            StreamWriter sw = new StreamWriter(strFilePath, true);
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(strErrMsg);
            sw.Flush();
            sw.Close();
        }

        public static void TraceLog(string strErrMsg, string filepath)
        {
            string strFilePath = "";


            strFilePath = filepath + "\\" + "TraceLog" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".txt";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            StreamWriter sw = new StreamWriter(strFilePath, true);
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(strErrMsg);
            sw.Flush();
            sw.Close();
        }
        #endregion Wrting Error to File
        #region File Writing to Path
        // Writes file to current folder
        public void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }
        #endregion File Writing to Path
    }
}
