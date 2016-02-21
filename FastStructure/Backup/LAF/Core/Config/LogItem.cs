/*
 * Description:This file is used to record log item information and contains a class LogItem.
 * Author: Zhang HeKe
 * Create Date:2007-6-11
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record log item information.
    /// Author:Zhang HeKe
    /// Create Date:2007-6-11
    /// </summary>
    public class LogItem
    {
        private LogDef m_LogDef;

        /// <summary>
        /// this constructor is used to get instance of LogDef
        /// </summary>
        public LogItem()
        {
            m_LogDef = new LogDef();
        }

        /// <summary>
        /// get or set the value of property LogDef
        /// </summary>
        public LogDef LogDef
        {
            get
            {
                return m_LogDef;
            }
            set
            {
                m_LogDef = value;
            }
        }
    }
}
