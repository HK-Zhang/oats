/*
 * Description:This file is used to listen action and contains a class ActionListenerItem.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record action listener information
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ActionListenerItem
    {
        protected string m_ActionId;
        protected EnumActionListenerOccasion m_Occasion;
        protected string m_ListenerType;
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
        /// get or set the value of propery Occasion
        /// </summary>
        public EnumActionListenerOccasion Occasion
        {
            get
            {
                return m_Occasion;
            }
            set
            {
                m_Occasion = value;
            }
        }

        /// <summary>
        /// get or set the value of propery ListenerType
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
