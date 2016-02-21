using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FastStructure.LAF.Messages
{
    public class CommonParameterParser : IMessageParser
    {


        public string Parse(string original, string[] parameters)
        {
            string replacedString = original;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append(i);
                    sb.Append("}");
                    if (parameters[i] != null)
                    {
                        replacedString = replacedString.Replace(sb.ToString(), parameters[i].ToString());
                    }

                }
            }
            return replacedString.Trim(); ;
        }


    }
}
