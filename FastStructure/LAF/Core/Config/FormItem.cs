/*
 * Description:This file is used to record information of form and contains a class FormItem.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record form information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class FormItem
    {
        protected string m_FormId;
        protected FormDef m_FormDef;
        protected DataDef m_DataDef;
        protected ActionDef m_ActionDef;

        /// <summary>
        /// initialization all object that are defined 
        /// </summary>
        public FormItem()
        {
            m_FormDef = new FormDef();
            m_DataDef = new DataDef();
            m_ActionDef = new ActionDef();
        }
        /// <summary>
        /// get or set the value of property FormId
        /// </summary>
        public string FormId
        {
            get
            {
                return m_FormId;
            }
            set
            {
                m_FormId = value;
            }
        }

        /// <summary>
        /// get or set the value of propery FormDef
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
        /// get or set the value of propery DataDef
        /// </summary>
        public DataDef DataDef
        {
            get
            {
                return m_DataDef;
            }
            set
            {
                m_DataDef = value;
            }
        }

        /// <summary>
        /// get or set the value of propery ActionDef
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
