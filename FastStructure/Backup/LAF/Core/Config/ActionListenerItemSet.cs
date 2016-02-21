/*
 * Description:This file is used to record general information and contains a class General.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using FastStructure.LAF.GenericType;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to collect action listener item
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ActionListenerItemSet
    {
        protected ArrayList<ActionListenerItem> m_ActionListenerItems;

        /// <summary>
        /// get the instance m_Items of ArrayList<ActionListenerItem>
        /// </summary>
        public ActionListenerItemSet()
        {
            m_ActionListenerItems = new ArrayList<ActionListenerItem>();
        }

        /// <summary>
        /// get or set the value of propery ActionListenerItems
        /// </summary>
        public ArrayList<ActionListenerItem> ActionListenerItems
        {
            get
            {
                return m_ActionListenerItems;
            }
            set
            {
                m_ActionListenerItems = value;
            }
        }

        /// <summary>
        /// get action types by listener type
        /// </summary>
        /// <param name="listenerType">a object of EnumActionListenerOccasion</param>
        /// <returns>all action types according to listenerType</returns>
        public ArrayList<ActionListenerItem> GetActionTypes(EnumActionListenerOccasion listenerType)
        {
            ArrayList<ActionListenerItem> actionList = new ArrayList<ActionListenerItem>();
            foreach (ActionListenerItem item in m_ActionListenerItems)
            {
                if (item.Occasion.Equals(listenerType))
                {
                    actionList.Add(item);
                }
            }
            return actionList;
        }
    }
}
