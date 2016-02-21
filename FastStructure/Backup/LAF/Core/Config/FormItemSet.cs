/*
 * Description:This file is used to collect form item and contains a class FormItemSet.
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
    /// Description:This class is used to collect form item
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class FormItemSet
    {
        protected ArrayList<FormItem> m_FormItems;
        protected EnumInstanceScope m_Scope;

        /// <summary>
        /// get the instance m_Items of Hashtable<FormItem>
        /// </summary>
        public FormItemSet()
        {
            m_FormItems = new ArrayList<FormItem>();
        }

        /// <summary>
        /// get or set the value of property FormItems
        /// </summary>
        public ArrayList<FormItem> FormItems
        {
            get
            {
                return m_FormItems;
            }
            set
            {
                m_FormItems = value;
            }
        }

        /// <summary>
        /// get form def information by form id
        /// </summary>
        /// <param name="formId">the id of form</param>
        /// <returns>a object of formdef</returns>
        public FormDef GetFormDef(string formId)
        {
            foreach (FormItem item in m_FormItems)
            {
                if (item.FormId.Equals(formId))
                {
                    return item.FormDef;
                }
            }
            return null;

        }

        /// <summary>
        /// get data def information by form id
        /// </summary>
        /// <param name="formId">the id of form</param>
        /// <returns>a object of datadef</returns>
        public DataDef GetDataDef(string formId)
        {
            foreach (FormItem item in m_FormItems)
            {
                if (item.FormId.Equals(formId))
                {
                    return item.DataDef;
                }
            }
            return null;
        }

        /// <summary>
        /// get action def information by form id
        /// </summary>
        /// <param name="formId">the id of form</param>
        /// <returns>a object of actiondef</returns>
        public ActionDef GetActionDef(string formId)
        {
            foreach (FormItem item in m_FormItems)
            {
                if (item.FormId.Equals(formId))
                {
                    return item.ActionDef;
                }
            }
            return null;
        }
    }
}
