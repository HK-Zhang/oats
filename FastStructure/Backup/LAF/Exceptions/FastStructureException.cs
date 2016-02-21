using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    public class FastStructureException : AbstractException
    {
        public FastStructureException() 
        {
        }

        public FastStructureException(string message) : base(message) 
        {

        }

        public override void SetConfig()
        {
            Level = FastStructureLogLevel.Debug;
            Methods.Add(FastStructureExceptionMethod.LOG);
        }
    }
}
