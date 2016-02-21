using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Messages;

namespace FastStructure.LAF.Core.Validation
{
    public class ValidateMessage
    {
        private static ValidateMessage m_PassedMessage;
        // private MessageManager m_MessageManager;
        private string key;
        private string[] parameters;
        public static ValidateMessage PassedMessage
        {
            get
            {
                if (m_PassedMessage == null)
                {
                    m_PassedMessage = new ValidateMessage();
                }
                return m_PassedMessage;
            }
        }

        private ValidateMessage()
        {
        }

        public ValidateMessage(string key, params string[] parameters)
        {
            this.key = key;
            this.parameters = parameters;
        }

        public string GetMessage(MessageManager msgMgr)
        {
            return msgMgr.GetMessage(key, parameters);
        }
    }
}
