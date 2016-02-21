/*
 * Description:This file contains a class LAFConfigurationSet which is used to implement interface ILAFConfiguration.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Exceptions;
using FastStructure.LAF.GenericType;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to collect all configuration and implemente the interface ILAFConfiguration
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class LAFConfigurationSet : ILAFConfiguration
    {
        #region all private member variables
        private ExceptionFormItem m_ExceptionFormItem;
        private ActionItemSet m_ActionItemSet;
        private ParameterListenerItemSet m_ParameterListenerItemSet;
        private FormItemSet m_FormItemSet;
        private ActionListenerItemSet m_ActionListenerItemSet;
        private String m_Assembly;
        private LogItem m_LogItem;
        private ArrayList<LAFConfiguration> m_ArrayConfig;
        private ArrayList<ILAFConfiguration> m_LAFConfigurations;
        private int count = 0;
        #endregion

        /// <summary>
        /// Initial instance of all objects above all declaration object
        /// </summary>
        public LAFConfigurationSet()
        {
            m_LogItem = new LogItem();
            m_ArrayConfig = new ArrayList<LAFConfiguration>();
            m_ExceptionFormItem = new ExceptionFormItem();
            m_ActionItemSet = new ActionItemSet();
            m_ParameterListenerItemSet = new ParameterListenerItemSet();
            m_FormItemSet = new FormItemSet();
            m_ActionListenerItemSet = new ActionListenerItemSet();
            m_LAFConfigurations = new ArrayList<ILAFConfiguration>();
        }

        /// <summary>
        /// get the value of property IsChanged 
        /// </summary>
        private bool IsChanged
        {
            get
            {
                return count != m_LAFConfigurations.Count;
            }
        }

        /// <summary>
        /// get all object of ILAFConfiguration
        /// </summary>
        public ArrayList<ILAFConfiguration> LAFConfigurations
        {
            get
            {
                Refresh();
                return m_LAFConfigurations;
            }
        }

        /// <summary>
        /// Get the  newest object of LAFConfiguration set
        /// </summary>
        private void Refresh()
        {
            if (IsChanged)
            {
                m_ActionItemSet.ActionItems.Clear();
                m_FormItemSet.FormItems.Clear();
                m_ParameterListenerItemSet.ParameterListeners.Clear();
                m_ActionListenerItemSet.ActionListenerItems.Clear();
                foreach (ILAFConfiguration config in m_LAFConfigurations)
                {
                    foreach (ActionItem item in config.ActionItemSet.ActionItems)
                    {
                        m_ActionItemSet.ActionItems.Add(item);
                    }
                    foreach (FormItem item in config.FormItemSet.FormItems)
                    {
                        m_FormItemSet.FormItems.Add(item);
                    }
                    foreach (ParameterListenerItem item in config.ParameterListenerItemSet.ParameterListeners)
                    {
                        m_ParameterListenerItemSet.ParameterListeners.Add(item);
                    }
                    foreach (ActionListenerItem item in config.ActionListenerItemSet.ActionListenerItems)
                    {
                        m_ActionListenerItemSet.ActionListenerItems.Add(item);
                    }
                    m_LogItem = config.LogItem;
                    m_ExceptionFormItem = config.ExceptionFormItem;
                }
            }
        }

        #region all properties of this class
        /// <summary>
        /// get or set the property Exceptionformitem
        /// </summary>
        public ExceptionFormItem ExceptionFormItem
        {
            get
            {
                Refresh();
                return LAFConfigurations[LAFConfigurations.Count - 1].ExceptionFormItem;
            }
            set
            {
                m_ExceptionFormItem = value;
            }
        }

        /// <summary>
        /// get or set the value of property LogItem
        /// </summary>
        public LogItem LogItem
        {
            get
            {
                Refresh();
                return m_LogItem;
            }
            set
            {
                m_LogItem = value;
            }
        }

        /// <summary>
        /// get or set the value of property ActionItemSet
        /// </summary>      
        public ActionItemSet ActionItemSet
        {
            get
            {
                Refresh();
                return m_ActionItemSet;
            }
            set
            {
                m_ActionItemSet = value;
            }
        }

        /// <summary>
        /// get or set the value of property ParameterListenerItemSet
        /// </summary>
        public ParameterListenerItemSet ParameterListenerItemSet
        {
            get
            {
                Refresh();
                return m_ParameterListenerItemSet;
            }
            set
            {
                m_ParameterListenerItemSet = value;
            }
        }
        /// <summary>
        /// get or set the value of property FormItemSet
        /// </summary>
        public FormItemSet FormItemSet
        {
            get
            {
                Refresh();
                return m_FormItemSet;
            }
            set
            {
                m_FormItemSet = value;
            }
        }

        /// <summary>
        /// get or set the value of property ActionListenerItemSet
        /// </summary>
        public ActionListenerItemSet ActionListenerItemSet
        {
            get
            {
                Refresh();
                return m_ActionListenerItemSet;
            }
            set
            {
                m_ActionListenerItemSet = value;
            }
        }

        /// <summary>
        /// get or set the value of property Assembly
        /// </summary>
        public String Assembly
        {
            get
            {
                return m_Assembly;
            }
            set
            {
                m_Assembly = value;
            }
        }
        #endregion
    }
}
