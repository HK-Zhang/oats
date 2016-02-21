/*
 * Description:This file is define a interface ,which is used to handle log file
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.LAFLog;

namespace FastStructure.Fast.Log
{
    /// <summary>
    /// Description:This class is define some function of LoggerManager which implement interface ILoggerManager
    /// Author: Zhang HeKe
    /// Create Date:2007-6-29
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        public LoggerManager()
        {
        }

        /// <summary>
        /// set log configuration file path
        /// </summary>
        public string ConfigFilePath
        {
            set
            {
                if (File.Exists(value))
                {
                    try
                    {
                        Stream stream = new FileStream(value, FileMode.Open);
                        log4net.Config.XmlConfigurator.Configure(stream);
                        stream.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// get log instance by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ILog GetLogger(string name)
        {
            return new Logger(name);
        }
    }
}
