/*
 * Description:This file is used to handle config not valid exception and contains a class NullReferenceException.
 * Author: Zhang HeKe
 * Create Date:2007-5-31
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    /// <summary>
    /// Description: This class is used to handle config not valid exception
    /// Author:Zhang HeKe
    /// Create Date:2007-5-31 
    /// <summary>
    public class NullReferenceException : AbstractException
    {
        public NullReferenceException()
        {

        }
        public NullReferenceException(string message)
            : base(message)
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
