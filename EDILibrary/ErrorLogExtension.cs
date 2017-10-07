using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uitlity;
using System.IO;


namespace EDIConvertorExecutable
{
    public class ErrorLogExtension
    {
        public static void ErrorLog(Exception exceptionMsg)
        {
            string path = AppKeyCollection.ErrorLogFolderName;
            string folderPath = Path.GetDirectoryName(AppKeyCollection.AppRootFolder) + "\\" + path;
            if (exceptionMsg.StackTrace != null)
            {
                ErrorModule.WriteErrorErrFile(exceptionMsg.StackTrace + "--->" + exceptionMsg.InnerException.TrimString(), folderPath, false);
            }
            else
            {
                ErrorModule.WriteErrorErrFile(exceptionMsg.Message.TrimString(), folderPath, false);
            }

        }

        public static void TraceLog(String message)
        { 
            string path = AppKeyCollection.TraceLogFolderName;
            string folderPath = Path.GetDirectoryName(AppKeyCollection.AppRootFolder) + "\\" + path;
            ErrorModule.TraceLog(message, folderPath);
        }
    }
}
