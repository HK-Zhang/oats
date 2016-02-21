using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Context;
namespace FastStructure.FastStructureContext
{
    public class BeforeActionContext
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
                return (string)m_ctx.GetParameter(EnumContextKey.BeforeContext.ToString());
            }
            set
            {
                m_ctx.SetParameter(EnumContextKey.BeforeContext.ToString(), value);
            }
        }
    }
}
