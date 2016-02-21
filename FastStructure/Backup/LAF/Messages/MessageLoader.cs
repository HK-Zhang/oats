using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

namespace FastStructure.LAF.Messages
{
    public class MessageLoader
    {
        public MessageSet LoadMessageSet(string file)
        {
            Hashtable table = new Hashtable();
            MessageSet messageSet = new MessageSet();

            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(file))
            {
                doc.Load(file);
                XmlNodeList msg_list = doc.GetElementsByTagName("message-list").Item(0).SelectNodes("message");

                foreach (System.Xml.XmlNode node in msg_list)
                {
                    table.Add(node.Attributes.GetNamedItem("key").Value, node.Attributes.GetNamedItem("pattern").Value);
                }
                messageSet.Messages = table;
            }
            return messageSet;
        }
    }
}
