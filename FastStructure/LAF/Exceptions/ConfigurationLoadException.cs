/*
 * Description:This file is used to handle configuration file load exception and contains a class ContentExistException.
 * Author: Zhang HeKe
 * Create Date:2007-6-1
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    /// <summary>
    /// Description:This class is used to handle configuration file load exception
    /// Author:Zhang HeKe
    /// Create Date:2007-6-1
    /// </summary>
    public class ConfigurationLoadException : AbstractException
    {
        public ConfigurationLoadException()
        {

        }

        public ConfigurationLoadException(string message)
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
