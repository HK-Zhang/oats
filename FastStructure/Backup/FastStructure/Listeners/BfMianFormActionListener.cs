using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;
using FastStructure.FastStructureContext;

namespace FastStructure.Fast.Listeners
{
    public class BfMianFormActionListener : AbstractListener
    {
        public override void Receive(IEvent eventItem)
        {
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            ctx.Result = "success";
        }
    }
}
