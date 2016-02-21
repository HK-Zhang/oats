/*
 * Description:This file is used to record action information and contains a class ActionItem.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record action information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ActionItem
    {
        protected string m_ActionId;
        protected string m_ActionType;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the value of propery ActionId
        /// </summary>
        public string ActionId
        {
            get
            {
                return m_ActionId;
            }
            set
            {
                m_ActionId = value;
            }
        }

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
