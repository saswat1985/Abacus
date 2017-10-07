using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for AppKeyCollection
/// </summary>
public static class AppKeyCollection
{
    public static string ImageFolderName { get; set; }
    public static string ImageRecordSize { get; set; }
    public static string WebSiteName { get; set; }
    public static string DefaultPwd { get; set; }
    public static string FromMail { get; set; }
    public static Int32 MaxExcelFileSize { get; set; }
    public static string WelcomeNote { get; set; }
    public static string ZipFilePath { get; set; }
    public static string ExcelFilePath { get; set; }

    static AppKeyCollection()
    {
        ImageFolderName = ConfigurationManager.AppSettings["ImageFolderName"].TrimString();
        ImageRecordSize = ConfigurationManager.AppSettings["RecordImageSize"].TrimString();
        WebSiteName = ConfigurationManager.AppSettings["WebSiteName"].TrimString();
        FromMail = ConfigurationManager.AppSettings["FromMailID"].TrimString();
        WelcomeNote = ConfigurationManager.AppSettings["WelcomeNote"].TrimString();
        DefaultPwd = ConfigurationManager.AppSettings["DefaultPwd"].TrimString();
        MaxExcelFileSize = Convert.ToInt32(ConfigurationManager.AppSettings["MaxExcelFileSize"].TrimString());
        ExcelFilePath = ConfigurationManager.AppSettings["ExcelFilePath"].TrimString();
        ZipFilePath = ConfigurationManager.AppSettings["ZipFilePath"].TrimString();

    }

}
