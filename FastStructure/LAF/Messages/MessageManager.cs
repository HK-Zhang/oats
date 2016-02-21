using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using FastStructure.LAF.Context;

namespace FastStructure.LAF.Messages
{
    public class MessageManager : IContextAware
    {
        private IContext m_Context;

        private List<IMessageParser> m_parsers;
        private MessageSet m_MessageSet;

        public MessageManager()
        {
            m_parsers = new List<IMessageParser>();
        }

        public IContext Context
        {
            get
            {
                return m_Context;
            }
            set
            {
                m_Context = value;
            }
        }

        public List<IMessageParser> Parsers
        {
            get
            {
                return m_parsers;
            }
            set
            {
                m_parsers = value;
            }
        }
        public MessageSet MessageSet
        {
            get
            {
                return m_MessageSet;
            }
            set
            {
                m_MessageSet = value;
            }
        }

        public void AddMessageParser(IMessageParser parser)
        {
            if (parser != null)
            {
                m_parsers.Add(parser);
            }
        }
        public string GetMessage(string msgKey)
        {
            return GetMessage(msgKey, null);
        }
        public string GetMessage(string msgKey, params string[] data_exp)
        {
            string original = m_MessageSet.GetMessage(msgKey).Pattern;
            if (m_parsers != null)
            {
                foreach (IMessageParser messageParse in m_parsers)
                {
                    if (messageParse.GetType().IsSubclassOf(typeof(IContextAware)))
                    {
                        IContextAware ca = (IContextAware)messageParse;
                        ca.Context = this.Context;
                    }
                    original = messageParse.Parse(original, data_exp);

                }
            }
            return original;
        }
        public void LoadMessageSet(string path)
        {
            m_MessageSet = new MessageLoader().LoadMessageSet(path);
            m_Context.AddParameter(this.GetType().ToString(), m_MessageSet);
        }

    }
}
