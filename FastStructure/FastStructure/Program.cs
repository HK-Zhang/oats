using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FastStructure.LAF.Context;
using FastStructure.LAF.Core;
using FastStructure.LAF.Core.Pool;
using System.Diagnostics;

namespace FastStructure.Fast
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process me = Process.GetCurrentProcess();
            Process[] process = Process.GetProcessesByName(me.ProcessName.Replace(".vshost", string.Empty));
            if (process.Length > 1)
            {
                me.Kill();
            }

            try
            {
                LAFManager.GetInstance().Initialize(System.IO.Directory.GetCurrentDirectory() + "\\conf\\");
                LAFManager.GetInstance().RequestGlobalAction("ADD-ENVIRONMENT-CONTEXT-ACTION");
                LAFManager.GetInstance().RequestForm("MAIN-FORM");
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}