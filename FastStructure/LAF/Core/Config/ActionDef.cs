/*
 * Description:This file is used to record difference of action and contains a class ActionDef.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record the difference action information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ActionDef
    {
        protected string m_ActionType;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the value of propery ActionType
        /// </summary>
        public string ActionType
        {
            get
            {
                return m_ActionType;
            }
            set
            {
                m_ActionType = value;
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
