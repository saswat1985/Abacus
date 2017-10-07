using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mime;
using System.Drawing;
using System.Drawing.Imaging;

namespace EDIConvertorExecutable
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {

                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromMinutes(AppKeyCollection.IntervalInMinut);
                var timer = new System.Threading.Timer((e) =>
                {
                    StartUp();
                }, null, startTimeSpan, periodTimeSpan);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                ErrorLogExtension.ErrorLog(ex);
            }

        }

        public static void StartUp()
        {
            try
            {
                StartupClass objClass = new StartupClass();
                objClass.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
