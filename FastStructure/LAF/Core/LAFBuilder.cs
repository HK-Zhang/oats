/*
 * Description:This file contains a class LAFBuilder to build ApplicationFramework.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Core.Pool;
using FastStructure.LAF.Context;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Messages;
using FastStructure.LAF.LAFLog;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// This class is used to build ApplicationFramework.
    /// First Step:LoadConfiguration
    /// Second Step:BuildApplicationContext
    /// Third Step:BuildObjectPool
    /// Forth Step:InitializeParameterListeners
    /// Fifth Step:RetrieveApplicationFramework
    /// </summary>
    public class LAFBuilder : ILAFBuilder
    {
        private LAFConfigurationSet configurationSet;
        private IObjectPool objectPool;
        private IContext applicationContext;
        // private IApplicationFramework framework;
        private MessageManager MsgManager;


        #region ILAFBuilder Members

        public void Initialize()
        {
            configurationSet = new LAFConfigurationSet();
        }

        /// <summary>
        /// Description:Load Configuration file
        /// </summary>
        /// <param name="filePath">the path of configuration</param>
        public void LoadConfiguration(string filePath)
        {
            configurationSet.LAFConfigurations.Add(LAFConfigurationDAOFacotry.GetLAFConfigurationDAO().LoadLAFConfiguration(filePath));
        }

        /// <summary>
        /// Description:Build application context.
        /// </summary>
        public void BuildApplicationContext()
        {
            applicationContext = ContextFactory.GetIContext();

        }

        /// <summary>
        /// Description:Build object pool.
        /// </summary>
        public void BuildObjectPool(string logPath)
        {
            objectPool = ObjectPoolFactory.GetIObjectPool(applicationContext, configurationSet, MsgManager, logPath);
            //objectPool.LoadForLAFConfiguration(configurationSet);
        }

        /// <summary>
        /// Description:Initialize Parameter Listeners
        /// </summary>
        public void InitializeParameterListeners()
        {
            IListener[] listeners = objectPool.GetParameterListeners();

            for (int i = 0; i < listeners.Length; i++)
            {
                applicationContext.AddParameterListeners(listeners[i]);
            }
        }

        /// <summary>
        /// Description:rerurn application framework
        /// </summary>
        /// <returns>ApplicationFramework</returns>
        public IApplicationFramework RetrieveApplicationFramework()
        {
            //framework.
            return ApplicationFrameworkFactory.GetIApplicationFramework(configurationSet, objectPool, applicationContext);
        }

        #endregion


        #region ILAFBuilder Members


        public void BuildMessage(string path)
        {
            MsgManager = new MessageManager();
            MsgManager.Context = applicationContext;
            IMessageParser comParser = new CommonParameterParser();
            IMessageParser ctxParser = new ContextParameterParser();
            MsgManager.AddMessageParser(comParser);
            MsgManager.AddMessageParser(ctxParser);
            MsgManager.LoadMessageSet(path);
        }

        #endregion
    }
}
