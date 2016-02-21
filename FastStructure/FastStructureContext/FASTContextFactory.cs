/*
 * Description:This file is define a interface ,which is used to handle log file
 * Author: Zhang HeKe
 * Create Date:2007-6-1
 */
using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Context;

namespace FastStructure.FastStructureContext
{
    /// <summary>
    /// Description:This class is used to set the context of combo language.
    /// Author:Zhang HeKe
    /// Create Date:2007-6-4
    /// </summary>
    public class FASTContextFactory
    {
        public static EnvironmentContext CreateEnvironmentContext(IContext ctx)
        {
            EnvironmentContext envi_context = new EnvironmentContext();
            envi_context.Context = ctx;
            return envi_context;
        }

        public static CaculateContext CreateCaculateContext(IContext ctx)
        {
            CaculateContext envi_context = new CaculateContext();
            envi_context.Context = ctx;
            return envi_context;
        }

        public static CaculateModeContext CreateCaculateModeContext(IContext ctx)
        {
            CaculateModeContext envi_context = new CaculateModeContext();
            envi_context.Context = ctx;
            return envi_context;
        }

        public static StepContext CreateStepContext(IContext ctx)
        {
            StepContext envi_context = new StepContext();
            envi_context.Context = ctx;
            return envi_context;
        }

        public static BeforeActionContext CreateBeforeActionContext(IContext ctx)
        {
            BeforeActionContext envi_context = new BeforeActionContext();
            envi_context.Context = ctx;
            return envi_context;
        }

        public static AfterActionContext CreateAfterActionContext(IContext ctx)
        {
            AfterActionContext envi_context = new AfterActionContext();
            envi_context.Context = ctx;
            return envi_context;
        }
    }
}
