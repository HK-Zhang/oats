/*
 * Description:This file contains a class ApplicationFrameworkFactory to maintain the instance of ApplicationFramework.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Core.Pool;
using FastStructure.LAF.Context;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// Description:This class is used to maintain the instance of ApplicationFramework
    /// Author:Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class ApplicationFrameworkFactory
    {
        public static IApplicationFramework GetIApplicationFramework(LAFConfigurationSet configurationSet, IObjectPool objectPool, IContext applicationContext)
        {
            ApplicationFramework framework = new ApplicationFramework();

            framework.ObjectPool = objectPool;
            framework.ConfigurationSet = configurationSet;
            framework.ApplicationContext = applicationContext;

            return framework;
        }
    }
}
