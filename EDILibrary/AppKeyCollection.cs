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
    public static int Maxthread { get; set; }
    public static int MaxthreadBorderImage { get; set; }
    public static string MoveZipFile { get; set; }
    public static string ErrorLogFolderName { get; set; }
    public static string FontStyle { get; set; }
    public static int FontSize { get; set; }
    public static string AppRootFolder { get; set; }
    public static string TraceLogFolderName { get; set; }
    public static int IntervalInMinut { get; set; }
    public static int RecordBorderImageSize { get; set; }

    static AppKeyCollection()
    {
        ImageFolderName = ConfigurationManager.AppSettings["ImageFolderName"].TrimString();
        ImageRecordSize = ConfigurationManager.AppSettings["RecordImageSize"].TrimString();
        ErrorLogFolderName = ConfigurationManager.AppSettings["ErrorLogFolderName"].TrimString();
        Maxthread = Convert.ToInt32(ConfigurationManager.AppSettings["Maxthread"]);
        FontStyle = ConfigurationManager.AppSettings["FontStyle"].TrimString();
        FontSize = Convert.ToInt32(ConfigurationManager.AppSettings["FontSize"].TrimString());
        AppRootFolder = ConfigurationManager.AppSettings["AppRootFolder"].TrimString();
        MoveZipFile = ConfigurationManager.AppSettings["MoveZipFile"].TrimString();
        TraceLogFolderName = ConfigurationManager.AppSettings["TraceLogFolderName"].TrimString();
        IntervalInMinut = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalInMinut"].TrimString());
        RecordBorderImageSize = Convert.ToInt32(ConfigurationManager.AppSettings["RecordBorderImageSize"].TrimString());
        MaxthreadBorderImage = Convert.ToInt32(ConfigurationManager.AppSettings["MaxthreadBorderImage"]);

    }

}
