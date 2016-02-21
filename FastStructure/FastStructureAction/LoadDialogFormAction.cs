using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core;

namespace FastStructure.FastStructureAction
{
    public class LoadDialogFormAction : AbstractAction
    {
        public override void Execute()
        {
            LAFManager.GetInstance().RequestDialog("DIALOG-FORM");
        }
    }
}
