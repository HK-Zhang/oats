/*
 * Description:This file is define a interface ,which is used to handle log file
 * Author: Zhang HeKe
 * Create Date:2007-6-1
 */
using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Context;

namespace FastStructure.FastStructureContext
{
    /// <summary>
    /// Description:This class is used to set the context of Environment.
    /// Author:Zhang HeKe
    /// Create Date:2007-6-4
    /// </summary>
    public class EnvironmentContext
    {
        private IContext m_ctx;

        private const string APP_NAME_KEY = "${ApplicationName}";
        private const string INSTALL_ROOT_KEY = "${InstallRoot}";

        public IContext Context
        {
            set
            {
                m_ctx = value;
            }
        }

        public string ApplicationName
        {
            set
            {
                m_ctx.SetParameter(APP_NAME_KEY, value);
            }
            get
            {
                return m_ctx.GetParameter(APP_NAME_KEY).ToString();
            }
        }

        public string InstallRoot
        {
            get
            {
                return m_ctx.GetParameter(INSTALL_ROOT_KEY).ToString();
            }
            set
            {
                m_ctx.SetParameter(INSTALL_ROOT_KEY, value);

            }
        }

    }
}
