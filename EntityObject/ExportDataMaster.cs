using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EntityRefObject
{
    public class MstExportData
    {
        public string Type { get; set; }
        public string FileCode { get; set; }
        public int ImageType { get; set; }
        public string UploadPath { get; set; }
        public int UploadBy { get; set; }
        public int RecordId { get; set; }
    }
}
