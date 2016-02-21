/*
 * Description:This file is used to handle same name exception and contains a class SameNameException.
 * Author: Zhang HeKe
 * Create Date:2007-5-29
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    /// <summary>
    /// Description:This class is used to handle same name exception
    /// Author:Zhang HeKe
    /// Create Date:2007-5-29
    /// </summary>
    public class SameNameException : AbstractException
    {
        public SameNameException()
        {

        }

        public SameNameException(string message)
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
