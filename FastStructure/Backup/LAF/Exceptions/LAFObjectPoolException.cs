using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    public class LAFObjectPoolException : AbstractException
    {
        public LAFObjectPoolException()
        {

        }

        public LAFObjectPoolException(string ErrorMsg)
            : base(ErrorMsg)
        {

        }

        public override void SetConfig()
        {
            Level = FastStructureLogLevel.Error;
            Methods.Add(FastStructureExceptionMethod.FORM);
            Methods.Add(FastStructureExceptionMethod.LOG);
        }
    }
}
