using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Messages
{
    public class Message
    {
        private string m_Key;
        private string m_Pattern;

        public string Key
        {
            get
            {
                return m_Key;
            }
            set
            {
                m_Key = value;
            }
        }
        public string Pattern
        {
            get
            {
                return m_Pattern;
            }
            set
            {
                m_Pattern = value;
            }
        }
    }
}
