using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core;
using FastStructure.Data.FormData;
using FastStructure.FastStructureContext;

namespace FastStructure.FastStructureAction
{
    public class CaculateModeAction : AbstractAction
    {
        public override void Execute()
        {
            CaculateModeContext ctx = FASTContextFactory.CreateCaculateModeContext(Context);

            ctx.Result = "Parm Event";
        }
    }
}
