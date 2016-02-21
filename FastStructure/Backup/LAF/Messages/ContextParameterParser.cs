using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using FastStructure.LAF.Context;

namespace FastStructure.LAF.Messages
{
    public class ContextParameterParser : IMessageParser, IContextAware
    {
        private IContext m_Context;

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

        public string Parse(string original, string[] parameters)
        {

            string replacedString = original;
            if (parameters != null)
            {
                string regularText = "\\${[^${*}]}";

                MatchCollection collection = Regex.Matches(replacedString, regularText);


                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i < collection.Count)
                    {
                        if (collection[i] != null)
                        {
                            if (parameters[i] != null)
                            {
                                replacedString = replacedString.Replace(collection[i].ToString(), parameters[i].ToString());
                            }
                        }
                    }
                }
            }
            return replacedString.Trim(); ;
        }
    }
}
