/*
 * Description:This file is used to record difference data of form and contains a class FormDef.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record the difference form information.
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class FormDef
    {
        protected string m_FormType;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the value of propery FormType
        /// </summary>
        public string FormType
        {
            get
            {
                return m_FormType;
            }
            set
            {
                m_FormType = value;
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
