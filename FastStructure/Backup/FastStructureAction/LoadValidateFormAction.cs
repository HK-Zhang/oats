using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core;

namespace FastStructure.FastStructureAction
{
    public class LoadValidateFormAction : AbstractAction
    {
        public override void Execute()
        {
            LAFManager.GetInstance().RequestForm("VALIDATE-FORM");
        }
    }
}
