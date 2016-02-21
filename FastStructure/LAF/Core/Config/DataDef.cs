/*
 * Description:This file is used to record difference of data and contains a class DataDef.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record the difference data information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class DataDef
    {
        protected string m_FormDataType;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the value of propery FormDataType
        /// </summary>
        public string FormDataType
        {
            get
            {
                return m_FormDataType;
            }
            set
            {
                m_FormDataType = value;
            }
        }

        /// <summary>
        /// get or set the value of propery Scope
        /// </summary>
        public EnumInstanceScope Scope
        {
            get
            {
                return m_Scope;
            }
            set
            {
                m_Scope = value;
            }
        }
    }
}
