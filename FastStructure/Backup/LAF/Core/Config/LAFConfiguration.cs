/*
 * Description:This file contains a class LAFConfiguration to impelment interface ILAFConfiguration.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FastStructure.LAF.Exceptions;


namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to implemente the interface ILAFConfiguration
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class LAFConfiguration : ILAFConfiguration
    {
        #region all const members
        private const string DIVIDE = "\\";
        private const string LAF_NAME = "LAF";
        private const string CURRENT_PATH = @"\FASTLocalizerSuite";
        private const string LAF_CONFIG_FILE = @"\conf\LAF.conf";
        #endregion

        #region all private member variables
        private ExceptionFormItem m_ExceptionFormItem;
        private ActionItemSet m_ActionItemSet;
        private ParameterListenerItemSet m_ParameterListenerItemSet;
        private FormItemSet m_FormItemSet;
        private ActionListenerItemSet m_ActionListenerItemSet;
        private LogItem m_LogItem;
        private int m_Version;
        private string m_LafConfigFilePath;
        #endregion

        /// <summary>
        /// Inital the version and get the instance of some object of LAFConfiguration
        /// </summary>
        public LAFConfiguration()
        {
            m_LogItem = new LogItem();
            m_FormItemSet = new FormItemSet();
            m_ActionItemSet = new ActionItemSet();
            m_ExceptionFormItem = new ExceptionFormItem();
            m_ActionListenerItemSet = new ActionListenerItemSet();
            m_ParameterListenerItemSet = new ParameterListenerItemSet();
            m_Version = 1;
            SetLAFPath();
        }

        #region all properties of this class
        /// <summary>
        /// get the value of property LAFConfigFilePath
        /// </summary>
        public string LAFConfigFilePath
        {
            get
            {
                return m_LafConfigFilePath;
            }
        }

        /// <summary>
        /// get or set the value of property Version
        /// </summary>
        public int Version
        {
            get
            {
                return m_Version;
            }
            set
            {
                m_Version = value;
            }
        }

        /// <summary>
        /// get or set the value of property LogItem
        /// </summary>
        public LogItem LogItem
        {
            get
            {
                return m_LogItem;
            }
            set
            {
                m_LogItem = value;
            }
        }

        /// <summary>
        /// get or set the value of property ExceptionFormItem
        /// </summary>
        public ExceptionFormItem ExceptionFormItem
        {
            get
            {
                return m_ExceptionFormItem;
            }
            set
            {
                m_ExceptionFormItem = value;
            }
        }

        /// <summary>
        /// get or set the value of property ActionItemSet
        /// </summary>
        public ActionItemSet ActionItemSet
        {
            get
            {
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
                return m_ActionListenerItemSet;
            }
            set
            {
                m_ActionListenerItemSet = value;
            }
        }
        #endregion

        /// <summary>
        /// Set the path of LAF
        /// </summary>
        private void SetLAFPath()
        {
            string current = Directory.GetCurrentDirectory();
            m_LafConfigFilePath = current + LAF_CONFIG_FILE;
        }
    }
}
