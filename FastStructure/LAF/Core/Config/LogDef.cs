/*
 * Description:This file is used to record log Def information and contains a class LogDef.
 * Author: Zhang HeKe
 * Create Date:2007-6-11
 */
using System;
using System.Collections.Generic;
using System.Text;


namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to record log Def information.
    /// Author:Zhang HeKe
    /// Create Date:2007-6-11
    /// </summary>
    public class LogDef
    {
        private string m_LogType;
        private string m_LogPath;
        private EnumInstanceScope m_Scope;

        /// <summary>
        /// get or set the property LogType
        /// </summary>
        public string LogType
        {
            get
            {
                return m_LogType;
            }
            set
            {
                m_LogType = value;
            }
        }

        /// <summary>
        /// get or set the property LogPath
        /// </summary>
        public string LogPath
        {
            get
            {
                return m_LogPath;
            }
            set
            {
                m_LogPath = value;
            }
        }

        /// <summary>
        /// get or set the property Scope
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
