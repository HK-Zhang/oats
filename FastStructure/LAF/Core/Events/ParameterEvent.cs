/*
 * Description:This file contains a class ParameterEvent, which inherit Abstract class AbstractEvent
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This clas supply ParameterEvent core founction
    /// Author: Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class ParameterEvent : AbstractEvent
    {
        //store to paramenterName 
        private string m_parameterName;

        //store to parameterOperationType
        private EnumParameterOperationType m_parameterOperationType;

        /// <summary>
        /// supply get or set method of ParameterName property
        /// </summary>
        public string ParameterName
        {
            get
            {
                return m_parameterName;
            }
            set
            {
                m_parameterName = value;
            }
        }

        /// <summary>
        /// supply  get or set method of ParameterOperationType property
        /// </summary>
        public EnumParameterOperationType ParameterOperationType
        {
            get
            {
                return m_parameterOperationType;
            }
            set
            {
                m_parameterOperationType = value;
            }
        }

        private object m_PreviousValue;
        public object PreviousValue
        {
            get
            {
                return m_PreviousValue;
            }
            set
            {
                m_PreviousValue = value;
            }
        }

        private object m_CurrentValue;
        public object CurrentValue
        {
            get
            {
                return m_CurrentValue;
            }
            set
            {
                m_CurrentValue = value;
            }
        }

        /// <summary>
        /// Constructor of ParameterEvent's property value
        /// </summary>
        /// <param name="paramterName">paramterName</param>
        /// <param name="parameterOperationType">parameterOperationType</param>
        public ParameterEvent(string paramterName, EnumParameterOperationType parameterOperationType)
        {
            this.m_parameterName = paramterName;
            this.m_parameterOperationType = parameterOperationType;
        }
    }
}
