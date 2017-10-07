using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using EDIConvertorExecutable;
using System.Timers;

namespace EDIConvertor
{
    public partial class ConvertWindowService : ServiceBase
    {
        Timer timer = new Timer();
      
        public ConvertWindowService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ErrorLogExtension.TraceLog("Start service:" + DateTime.Now.ToString());
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000;
            timer.Enabled = true;
            
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            ErrorLogExtension.TraceLog("Stop service:" + DateTime.Now.ToString());
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            System.Diagnostics.Debugger.Launch();
            StartupClass objClass = new StartupClass();
            objClass.Start();
        }
    }
}
