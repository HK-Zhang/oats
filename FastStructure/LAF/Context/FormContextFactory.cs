/*
 * Description:This file is define a interface ,which is used to handle log file
 * Author: Zhang HeKe
 * Create Date:2007-6-1
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Context
{
    public class FormContextFactory
    {

        public static FormContext GetFormContext(IContext ctx, string formId)
        {
            FormContext formContext = new FormContext();
            formContext.Context = ctx;
            formContext.FormId = formId;
            return formContext;
        }
    }
}
