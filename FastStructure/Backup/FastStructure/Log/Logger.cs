/*
 * Description:This file is define a class ,which is used to handle log information.
 * Author: Zhang HeKe
 * Create Date:2007-6-29
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FastStructure.LAF.LAFLog;

namespace FastStructure.Fast.Log
{
    /// <summary>
    /// Description:This class is define some function of Logger which implement interface ILog
    /// Author: Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class Logger : ILog
    {
        #region Attribute

        private log4net.ILog logger;

        #endregion

        #region constitutor
        /// <summary>
        /// Initialize value of property m_logFilePath
        /// </summary>
        /// <param name="logFilePath">logFilePath</param>
        public Logger(string name)
        {
            logger = log4net.LogManager.GetLogger(name);
        }
        #endregion

        #region Debug log
        /// <summary>
        /// supply debug information handle
        /// </summary>
        /// <param name="debugInfo">debugInfo</param>
        public void Debug(string debugInfo)
        {
            if (debugInfo != null)
            {
                logger.Debug(debugInfo);
            }
        }
        #endregion

        #region Error log
        /// <summary>
        /// supply error information handle
        /// </summary>
        /// <param name="errorInfo">errorInfo</param>
        public void Error(string errorInfo)
        {
            if (errorInfo != null)
            {
                logger.Error(errorInfo);
            }
        }
        #endregion

        #region Warning log
        /// <summary>
        /// supply warning information handle
        /// </summary>
        /// <param name="warningInfo">warningInfo</param>
        public void Info(string info)
        {
            if (info != null)
            {
                logger.Info(info);
            }
        }
        #endregion

        public void Fatal(string fatalInfo)
        {
            if (fatalInfo != null)
            {
                logger.Fatal(fatalInfo);
            }
        }
    }
}
