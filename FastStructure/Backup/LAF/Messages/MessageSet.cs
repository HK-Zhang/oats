using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FastStructure.LAF.Messages
{
    public class MessageSet
    {
        private Hashtable m_Messages;

        public Hashtable Messages
        {
            get
            {
                return m_Messages;
            }
            set
            {
                m_Messages = value;
            }
        }

        public MessageSet()
        {
            m_Messages = new Hashtable();
        }

        public Message GetMessage(string key)
        {
            Message message = new Message();

            if (m_Messages.ContainsKey(key))
            {
                message.Key = key;
                message.Pattern = m_Messages[key].ToString();
                return message;
            }
            return null;

        }
    }
}
