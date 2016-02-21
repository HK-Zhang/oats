using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;
using FastStructure.FastStructureContext;

namespace FastStructure.Fast.Listeners
{
    public class BeforeStepActionListener : AbstractListener
    {
        public override void Receive(IEvent eventItem)
        {
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            BeforeActionContext bctx = FASTContextFactory.CreateBeforeActionContext(Context);
            ctx.Result = ctx.Result + " " + bctx.Result + "(" + (eventItem as BeforeActionExecuteEvent).ActionID + ")";
        }
    }
}
