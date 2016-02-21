using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Validation;

namespace FastStructure.Data.FormData
{
    public class ValidateFormData : IValidatable
    {
        private const string MSG_REQUIRED = "error.required";
        private const string MSG_INVALID_INPUT = "error.tooBigInput";

        private int rangeInt;

        public int RangeInt
        {
            get { return rangeInt; }
            set { rangeInt = value; }
        }

        private string requireStr;

        public string RequireStr
        {
            get { return requireStr; }
            set { requireStr = value; }
        }
	

        #region IValidatable Members

        public ValidateMessage Validate()
        {
            ValidateMessage validMsg;

            if (string.IsNullOrEmpty(RequireStr)) 
            {
                validMsg = ValidateMessageFactory.CreateValidateMessage(MSG_REQUIRED, "String Value");
                return validMsg;
            }

            if (rangeInt > 10) 
            {
                validMsg = ValidateMessageFactory.CreateValidateMessage(MSG_INVALID_INPUT, "Int Value", "10");
                return validMsg;
            }

            return ValidateMessage.PassedMessage;
        }

        #endregion
    }
}
