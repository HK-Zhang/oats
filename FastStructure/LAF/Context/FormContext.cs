/*
 * Description:This file is define a interface ,which is used to handle log file
 * Author: Zhang HeKe
 * Create Date:2007-6-3
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.LAFComponents;

namespace FastStructure.LAF.Context
{
    public class FormContext
    {
        private IContext m_context;
        private string m_formId;



        public IContext Context
        {
            set
            {
                m_context = value;
            }
        }

        public string FormId
        {
            set
            {
                m_formId = value;
            }
        }

        public Form FormInstance
        {
            get
            {
                return (Form)m_context.GetParameter(m_formId + EnumContextPostfix.FormInstancePostfix.ToString());
            }
            set
            {
                m_context.SetParameter(m_formId + EnumContextPostfix.FormInstancePostfix.ToString(), value);
            }
        }
        public IAction FormAction
        {
            get
            {
                return (IAction)m_context.GetParameter(m_formId + EnumContextPostfix.FormActionPostfix.ToString());
            }
            set
            {
                m_context.SetParameter(m_formId + EnumContextPostfix.FormActionPostfix.ToString(), value);
            }
        }
        public object FormData
        {
            get
            {
                return m_context.GetParameter(m_formId + EnumContextPostfix.FormDataPostfix.ToString());
            }
            set
            {
                m_context.SetParameter(m_formId + EnumContextPostfix.FormDataPostfix.ToString(), value);
            }
        }
    }
}
