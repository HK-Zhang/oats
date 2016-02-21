using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core;
using FastStructure.Data.FormData;
using FastStructure.FastStructureContext;

namespace FastStructure.FastStructureAction
{
    public class StepAction : AbstractAction
    {
        public override void Execute()
        {
            StepContext ctx = FASTContextFactory.CreateStepContext(Context);
            ctx.Result = ctx.Result + " execute";
        }
    }
}
