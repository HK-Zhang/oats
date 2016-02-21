/*
 * Description:This file contains a class LAF to supply ApplicationFramework core functions
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.LAFLog;
using FastStructure.LAF.Exceptions;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// Description:This class supply ApplicationFramework core functions
    /// </summary>
    public class LAFManager : IApplicationFramework
    {

        private IApplicationFramework framework;

        const string ConfigPath = "LAF.conf";
        const string MessagePath = "Messages.res";
        //const string LogPath = "Localizer.log";
        const string LogConfigPath = "log.Conf";

        private LAFManager()
        {
            //Initialize();
        }

        private static class LazyHolder
        {
            public static readonly LAFManager Instance = new LAFManager();
        }

        /// <summary>
        /// Description:return singleton laf
        /// </summary>
        /// <returns>LAF</returns>
        public static LAFManager GetInstance()
        {
            return LazyHolder.Instance;
        }

        public void Initialize(string filePath)
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ExceptionHandle);
            ILAFBuilder builder = LAFBuilderFactory.GetILAFBuilder();
            builder.Initialize();
            builder.LoadConfiguration(filePath + ConfigPath);
            builder.BuildApplicationContext();
            builder.BuildMessage(filePath + MessagePath);
            //builder.BuildObjectPool(filePath + LogPath);
            builder.BuildObjectPool(filePath + LogConfigPath);
            builder.InitializeParameterListeners();
            framework = builder.RetrieveApplicationFramework();
        }

        private void ExceptionHandle(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

          Exception ex= e.Exception.GetBaseException();

          if (ex is AbstractException)
          {
              AbstractException realEx = ex as AbstractException;

              foreach (FastStructureExceptionMethod item in realEx.Methods)
              {
                  switch (item)
                  {
                      case FastStructureExceptionMethod.FORM:
                          RequestExceptionForm(realEx.Message);
                          break;
                      case FastStructureExceptionMethod.LOG:
                          LogException(realEx);
                          break;
                      case FastStructureExceptionMethod.MAIL:
                          break;
                      case FastStructureExceptionMethod.CELLPHONE:
                          break;
                      default:
                          break;
                  }
              }

          }
          else 
          {
              RequestExceptionForm(e.Exception.Message);
              LogException(e.Exception);
          }

        }

        private void InitializeActionListeners()
        {

        }

        #region IApplicationFramework Members

        /// <summary>
        /// Show form using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public void RequestForm(string formId)
        {
            framework.RequestForm(formId);
        }

        /// <summary>
        /// Show dialog using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public DialogResult RequestDialog(string formId)
        {
            return framework.RequestDialog(formId);
        }

        /// <summary>
        /// Get form data from object pool
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        /// <returns>the data model object of the corresponding form</returns>
        public object GetFormData(string formId)
        {
            return framework.GetFormData(formId);
        }

        /// <summary>
        /// Execute form action using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public void RequestFormAction(string formId)
        {
            framework.RequestFormAction(formId);
        }

        /// <summary>
        /// Execute global action using formid
        /// </summary>
        /// <param name="actionId">An identifier attribute of the specific action</param>
        public void RequestGlobalAction(string actionId)
        {
            framework.RequestGlobalAction(actionId);
        }

        ///// <summary>
        ///// Add actions which will be executed bofore current action execution
        ///// </summary>
        ///// <param name="action">action</param>
        //public void AddBeforeActionExecutionListener(IListener listener)
        //{
        //    framework.AddBeforeActionExecutionListener(listener);
        //}


        ///// <summary>
        ///// Add actions which will be executed after current action execution
        ///// </summary>
        ///// <param name="action">action</param>
        //public void AddAfterActionExecutionListener(IListener listener)
        //{
        //    framework.AddAfterActionExecutionListener(listener);
        //}

        /// <summary>
        /// Add LAFConfiguration to LAFConfigurationset
        /// </summary>
        /// <param name="lafConfiguration">LAFConfiguration</param>
        public void AddLAFConfiguration(ILAFConfiguration lafConfiguration)
        {
            framework.AddLAFConfiguration(lafConfiguration);
        }


        public void RequestExceptionForm(string errorMsg)
        {
            framework.RequestExceptionForm(errorMsg);
        }


        public void AddLogerPath(string logPath)
        {
            framework.AddLogerPath(logPath);
        }


        public void LogException(Exception ex)
        {
            framework.LogException(ex);
        }

        #endregion
    }
}
