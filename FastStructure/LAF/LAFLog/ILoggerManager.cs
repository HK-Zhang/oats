/*
 * Description:This file contains a interface to supply some function of Log
 * Author: Zhang HeKe
 * Create Date:2007-6-29
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.LAFLog
{
    /// <summary>
    /// Description:This interface supply some core function of ILoggerManager
    /// Author: Zhang HeKe
    /// Create Date:2007-6-29
    /// </summary>
    public interface ILoggerManager
    {
        /// <summary>
        /// Get log by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ILog GetLogger(string name);

        /// <summary>
        /// log configuration file path
        /// </summary>
        string ConfigFilePath
        {
            set;
        }
    }
}
