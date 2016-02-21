/*
 * Description:This file contains a Interface to supply some function,which implement it
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.LAFLog
{
    /// <summary>
    /// Description:This interface supply some core function of ILog
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// supply debug information handle
        /// </summary>
        /// <param name="debugInfo">debugInfo</param>
        void Debug(string debugInfo);

        /// <summary>
        /// supply error information handle
        /// </summary>
        /// <param name="errorInfo">errorInfo</param>
        void Error(string errorInfo);

        /// <summary>
        /// supply info information handle
        /// </summary>
        /// <param name="warningInfo">warningInfo</param>
        void Info(string info);

        /// <summary>
        /// supply fatal information handle
        /// </summary>
        /// <param name="fatalInfo">fatalInfo</param>
        void Fatal(string fatalInfo);
    }
}
