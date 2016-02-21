/*
 * Description:This file is used to maintain action item set informations and contains a class ActionItemSet.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.GenericType;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to collect action item
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ActionItemSet
    {
        protected ArrayList<ActionItem> m_ActionItems;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get a instance m_Items of Hashtable<ActionItem>
        /// </summary>
        public ActionItemSet()
        {
            m_ActionItems = new ArrayList<ActionItem>();
        }

        /// <summary>
        /// get or set the value of propery ActionItems
        /// </summary>
        public ArrayList<ActionItem> ActionItems
        {
            get
            {
                return m_ActionItems;
            }
            set
            {
                m_ActionItems = value;
            }
        }

        /// <summary>
        /// get action type by item id
        /// </summary>
        /// <param name="itemId">the key of item</param>
        /// <returns></returns>
        public string GetActionType(string itemId)
        {
            foreach (ActionItem item in m_ActionItems)
            {
                if (item.ActionId.Equals(itemId))
                {
                    return item.ActionType;
                }
            }
            return "";
        }

        /// <summary>
        /// get scope by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public EnumInstanceScope GetScope(string itemId)
        {
            foreach (ActionItem item in m_ActionItems)
            {
                if (item.ActionId.Equals(itemId))
                {
                    return item.Scope;
                }
            }
            return EnumInstanceScope.SINGLETON;
        }
    }
}
