/*
 * Description:This file is used to handle exceptions and contains a class ExceptionFormItem.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Exceptions
{
    /// <summary>
    /// Description:This class is used to handle exceptions
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ExceptionFormItem
    {
        protected FormDef m_FormDef;
        protected ActionDef m_ActionDef;

        /// <summary>
        /// get or set the value of property FormDef
        /// </summary>
        public FormDef FormDef
        {
            get
            {
                return m_FormDef;
            }
            set
            {
                m_FormDef = value;
            }
        }

        /// <summary>
        /// get or set the value of property ActionDef
        /// </summary>
        public ActionDef ActionDef
        {
            get
            {
                return m_ActionDef;
            }
            set
            {
                m_ActionDef = value;
            }
        }
    }
}
