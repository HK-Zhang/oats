using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Context;
using FastStructure.LAF.LAFLog;
using FastStructure.LAF.Messages;

namespace FastStructure.LAF.Core.LAFActions
{
    public abstract class AbstractAction : IContextAware, IAction
    {
        private IContext m_ctx;
        public IContext Context
        {
            get
            {
                return m_ctx;
            }
            set
            {
                m_ctx = value;
            }
        }

        private ILoggerManager m_loggerManager;
        public ILoggerManager LoggerManager
        {
            get
            {
                return m_loggerManager;
            }
            set
            {
                m_loggerManager = value;
            }
        }

        private MessageManager m_MessageManager;
        /// <summary>
        /// Message manager
        /// </summary>
        public MessageManager MessageManager
        {
            get
            {
                return m_MessageManager;
            }
            set
            {
                m_MessageManager = value;
            }
        }

        // if this action is connected to a form, this attribute will be assigned by LAF
        private string m_FormId;
        public string FormId
        {
            get
            {
                return m_FormId;
            }
            set
            {
                m_FormId = value;
            }
        }

        // if this action is connected to a form, this funntion returns the FormContext
        public FormContext GetFormContext()
        {
            if (!string.IsNullOrEmpty(m_FormId))
            {
                return FormContextFactory.GetFormContext(Context, m_FormId);
            }
            else
            {
                return null;
            }
        }

        protected void RequestGlobalAction(string actionId)
        {
            LAF.Core.LAFManager.GetInstance().RequestGlobalAction(actionId);
        }

        abstract public void Execute();
    }
}
