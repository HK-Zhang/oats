using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Exceptions
{
    public abstract class AbstractException:Exception
    {
        private FastStructureLogLevel level;

        public FastStructureLogLevel Level
        {
            get { return level; }
            set { level = value; }
        }

        private List<FastStructureExceptionMethod> methods=new List<FastStructureExceptionMethod>();

        public List<FastStructureExceptionMethod> Methods
        {
            get { return methods; }
            set { methods = value; }
        }

        public AbstractException() 
        {
            SetConfig();
        }

        public AbstractException(string message) : base(message) 
        {
            SetConfig();
        }

        public abstract void SetConfig();
	
    }
}
