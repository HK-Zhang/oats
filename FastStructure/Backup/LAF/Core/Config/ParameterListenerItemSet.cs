/*
 * Description:This file is used to collect parameter listener and contains a class ParameterListenerItemSet.
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
    /// Description:This class is used to collect parameter listener item.
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class ParameterListenerItemSet
    {
        protected ArrayList<ParameterListenerItem> m_ParameterListeners;

        /// <summary>
        /// initialization the object m_ParameterListeners
        /// </summary>
        public ParameterListenerItemSet()
        {
            m_ParameterListeners = new ArrayList<ParameterListenerItem>();
        }

        /// <summary>
        /// get or set the value of property  ParameterListeners
        /// </summary>
        public ArrayList<ParameterListenerItem> ParameterListeners
        {
            get
            {
                return m_ParameterListeners;
            }
            set
            {
                m_ParameterListeners = value;
            }
        }
    }
}
