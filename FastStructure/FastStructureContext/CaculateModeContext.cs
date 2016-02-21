using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Context;

namespace FastStructure.FastStructureContext
{
    public class CaculateModeContext
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
                return (string)m_ctx.GetParameter(EnumContextKey.CaculateMode.ToString());
            }
            set
            {
                m_ctx.SetParameter(EnumContextKey.CaculateMode.ToString(), value);
            }
        }
    }
}
