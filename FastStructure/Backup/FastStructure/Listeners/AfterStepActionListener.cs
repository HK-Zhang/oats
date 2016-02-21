using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;
using FastStructure.FastStructureContext;

namespace FastStructure.Fast.Listeners
{
    public class AfterStepActionListener : AbstractListener
    {
        public override void Receive(IEvent eventItem)
        {
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            AfterActionContext actx = FASTContextFactory.CreateAfterActionContext(Context);
            ctx.Result = ctx.Result + " " + actx.Result + "(" + (eventItem as AfterActionExecuteEvent).ActionID + ")";
        }
    }
}
