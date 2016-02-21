using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Messages;

namespace FastStructure.LAF.Core.Validation
{
    public class ValidateMessageFactory
    {
        public static ValidateMessage CreateValidateMessage(string key, params string[] parameters)
        {
            return new ValidateMessage(key, parameters);
        }

        public static ValidateMessage CreateValidateMessage(string key)
        {
            return new ValidateMessage(key, null);
        }
    }
}
