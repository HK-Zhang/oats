using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Messages
{
    public interface IMessageParser
    {
        string Parse(string original, string[] data_exp);
    }
}
