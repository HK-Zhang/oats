/*
 * Description:This file is used to handle config not valid exception and contains a class ConfigurationNotValidException.
 * Author: Zhang HeKe
 * Create Date:2007-5-29
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    /// <summary>
    /// Description:This class is used to handle config not valid exception
    /// Author:Zhang HeKe
    /// Create Date:2007-5-29
    /// </summary>
    public class ConfigurationNotValidException : AbstractException
    {
        public ConfigurationNotValidException()
        {

        }

        public ConfigurationNotValidException(string message)
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
