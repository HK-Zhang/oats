using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core;
using FastStructure.Data.FormData;
using FastStructure.FastStructureContext;

namespace FastStructure.FastStructureAction
{
    public class CaculateAction : AbstractAction
    {
        public override void Execute()
        {
            FormId = "VALIDATE-FORM";

            ValidateFormData frmData = (ValidateFormData)GetFormContext().FormData;

            CaculateContext ctx = FASTContextFactory.CreateCaculateContext(Context);

            ctx.Result = frmData.RangeInt.ToString();
            LAFManager.GetInstance().RequestForm("REQUEST-FORM");

        }
    }
}
