using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Context;

namespace FastStructure.FastStructureContext
{
    public class StepContext
    {
        private IContext m_ctx;

        public IContext Context
        {
            set
            {
                m_ctx = value;
            }
        }

        public string Result
        {
            get
            {
                return (string)m_ctx.GetParameter(EnumContextKey.Step.ToString());
            }
            set
            {
                m_ctx.SetParameter(EnumContextKey.Step.ToString(), value);
            }
        }
    }
}
