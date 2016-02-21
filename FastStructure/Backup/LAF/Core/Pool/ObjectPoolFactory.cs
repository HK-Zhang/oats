/*
 * Description:This file contains a class ObjectPoolFactory to maintain the instance of LAFObjectPool.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Context;
using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Messages;
using FastStructure.LAF.LAFLog;


namespace FastStructure.LAF.Core.Pool
{
    /// <summary>
    /// Description:This class is used to maintain the instance of LAFObjectPool
    /// Author:Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class ObjectPoolFactory
    {
        public static IObjectPool GetIObjectPool(IContext ctx, ILAFConfiguration lafConf, MessageManager msgManager, string logPath)
        {
            LAFObjectPool pool = new LAFObjectPool();
            pool.ContextInstance = ctx;
            pool.LoadForLAFConfiguration(lafConf);
            pool.MsgManger = msgManager;
            //pool.Logger = logger;
            pool.InitialFormData();
            pool.InitialLoggerManager(logPath);
            return pool;
        }
    }
}
