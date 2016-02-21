using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.FastStructureContext;

namespace FastStructure.FastStructureAction
{
    public class SaveEnvironmentInfoAction : AbstractAction
    {
        private const string APP_NAME = "FastStructure";
        public override void Execute()
        {
            EnvironmentContext ctx = FASTContextFactory.CreateEnvironmentContext(this.Context);
            ctx.ApplicationName = APP_NAME;
            ctx.InstallRoot = System.IO.Directory.GetCurrentDirectory();

        }
    }
}
