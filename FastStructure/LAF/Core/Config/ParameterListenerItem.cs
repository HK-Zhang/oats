/*
 * Description:This file is used to record general information and contains a class ParameterListenerItem.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record parameter listener item information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ParameterListenerItem
    {
        protected string m_ListenerType;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the value of ListenerType
        /// </summary>
        public string ListenerType
        {
            get
            {
                return m_ListenerType;
            }
            set
            {
                m_ListenerType = value;
            }
        }

        /// <summary>
        /// get or set the value of Scope
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
