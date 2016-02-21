/*
 * Description:This file contains a class ApplicationFramework to supply core function .
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.GenericType;
using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Core.Pool;
using FastStructure.LAF.Context;
using FastStructure.LAF.LAFComponents;
using FastStructure.LAF.LAFLog;
using FastStructure.LAF.Exceptions;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// Description:This class supply core function .
    /// </summary>
    public class ApplicationFramework : IApplicationFramework
    {

        private LAFConfigurationSet _configurationSet;
        private IObjectPool _objectPool;
        private IContext _applicationContext;
        const string FORM_ACTION_POSTFIX = ".action";
        const string LAF_EXCEPTION = "LAF.System.Exception";
        const string REFRESH_METHOD = "RefreshForm";
        const string FORM_ID = "FormId";
        const string FORM_INSTANCE_POSTFIX = ".instance";
        private bool majorThreadStarted = false;

        public IContext ApplicationContext
        {
            get
            {
                return _applicationContext;
            }
            set
            {
                _applicationContext = value;
            }
        }


        public IObjectPool ObjectPool
        {
            get
            {
                return _objectPool;
            }
            set
            {
                _objectPool = value;
            }
        }

        public LAFConfigurationSet ConfigurationSet
        {
            get
            {
                return _configurationSet;
            }
            set
            {
                _configurationSet = value;
            }
        }


        #region IApplicationFramework Members

        /// <summary>
        /// Show form using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public void RequestForm(string formId)
        {
            LAFForm form = ObjectPool.GetFormInstance(formId);

            form.LoadData();
            form.InitializeComponent();
            form.threadRunning.WaitOne();

            form.RefreshForm();
            form.FormId = formId;

            /*
            Type type = form.GetType();
            if (type.IsSubclassOf(typeof(LAFForm)))
            {
                (form as LAFForm).LoadData();
                (form as LAFForm).InitializeComponent();
                (form as LAFForm).threadRunning.WaitOne();

                (form as LAFForm).RefreshForm();
                (form as LAFForm).FormId = formId;

                //System.Reflection.MethodInfo method = type.GetMethod(REFRESH_METHOD);
                //System.Reflection.PropertyInfo pifo = type.GetProperty(FORM_ID);
                //pifo.SetValue(form, formId, null);
                //method.Invoke(form, null);
            }
             */

            FormContext fctx = FormContextFactory.GetFormContext(ApplicationContext, formId);
            fctx.FormInstance = form;

            IAction action = ObjectPool.GetFormAction(formId);

            if (action != null)
            {
                Type actionType = action.GetType();

                System.Reflection.PropertyInfo actionpifo = actionType.GetProperty(FORM_ID);
                if (actionpifo != null)
                {
                    actionpifo.SetValue(action, formId, null);
                }
            }


            fctx.FormAction = action;
            fctx.FormData = GetFormData(formId);
            //ApplicationContext.AddParameter(FORM_INSTANCE_POSTFIX, form);
            if (majorThreadStarted == false)
            {
                majorThreadStarted = true;
                Application.Run(form);
            }
            else
            {
                form.Show();
            }

        }

        /// <summary>
        /// Show dialog using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public DialogResult RequestDialog(string formId)
        {
            LAFForm form = ObjectPool.GetFormInstance(formId);

            form.LoadData();
            form.InitializeComponent();
            form.threadRunning.WaitOne();

            form.RefreshForm();
            form.FormId = formId;

            /*
            Type type = form.GetType();
            if (type.IsSubclassOf(typeof(LAFForm)))
            {
                (form as LAFForm).LoadData();
                (form as LAFForm).InitializeComponent();
                (form as LAFForm).threadRunning.WaitOne();

                (form as LAFForm).RefreshForm();
                (form as LAFForm).FormId = formId;

                //System.Reflection.MethodInfo method = type.GetMethod(REFRESH_METHOD);
                //System.Reflection.PropertyInfo pifo = type.GetProperty(FORM_ID);
                //pifo.SetValue(form, formId, null);
                //method.Invoke(form, null);
                ////((LAFForm)form).Refresh();
            }
             */

            //ApplicationContext.AddParameter(FORM_INSTANCE_POSTFIX, form);
            FormContext fctx = FormContextFactory.GetFormContext(ApplicationContext, formId);
            fctx.FormInstance = form;

            IAction action = ObjectPool.GetFormAction(formId);

            if (action != null)
            {
                Type actionType = action.GetType();

                System.Reflection.PropertyInfo actionpifo = actionType.GetProperty(FORM_ID);
                if (actionpifo != null)
                {
                    actionpifo.SetValue(action, formId, null);
                }
            }

            fctx.FormAction = action;
            fctx.FormData = GetFormData(formId);

            return form.ShowDialog();
        }

        /// <summary>
        /// Get form data from object pool
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        /// <returns>the data model object of the corresponding form</returns>
        public object GetFormData(string formId)
        {
            return ObjectPool.GetFormData(formId);

        }

        /// <summary>
        /// Execute form action using formid
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        public void RequestFormAction(string formId)
        {
            StringBuilder sb = new StringBuilder(formId);
            sb.Append(FORM_ACTION_POSTFIX);
            IListener[] BeforeListeners = ObjectPool.GetActionListeners(sb.ToString(), EnumActionListenerOccasion.BEFORE);
            IListener[] AfterListeners = ObjectPool.GetActionListeners(sb.ToString(), EnumActionListenerOccasion.AFTER);

            BeforeActionExecuteEvent beforeE = new BeforeActionExecuteEvent();
            AfterActionExecuteEvent afterE = new AfterActionExecuteEvent();
            beforeE.ActionID = formId;
            afterE.ActionID = formId;

            for (int i = 0; i < BeforeListeners.Length; i++)
            {
                BeforeListeners[i].Receive(beforeE);
            }

            IAction formAction = ObjectPool.GetFormAction(formId);
            formAction.Execute();

            for (int i = 0; i < AfterListeners.Length; i++)
            {
                AfterListeners[i].Receive(afterE);
            }
        }

        /// <summary>
        /// Execute global action using formid
        /// </summary>
        /// <param name="actionId">An identifier attribute of the specific action</param>
        public void RequestGlobalAction(string actionId)
        {
            IListener[] BeforeListeners = ObjectPool.GetActionListeners(actionId, EnumActionListenerOccasion.BEFORE);
            IListener[] AfterListeners = ObjectPool.GetActionListeners(actionId, EnumActionListenerOccasion.AFTER);

            BeforeActionExecuteEvent beforeE = new BeforeActionExecuteEvent();
            AfterActionExecuteEvent afterE = new AfterActionExecuteEvent();
            beforeE.ActionID = actionId;
            afterE.ActionID = actionId;

            for (int i = 0; i < BeforeListeners.Length; i++)
            {
                BeforeListeners[i].Receive(beforeE);
            }

            IAction globalAction = ObjectPool.GetAction(actionId);

            //Type type = globalAction.GetType();
            //System.Reflection.MethodInfo method = type.GetMethod("Execute");
            //method.Invoke(globalAction, null);

            globalAction.Execute();

            for (int i = 0; i < AfterListeners.Length; i++)
            {
                AfterListeners[i].Receive(afterE);
            }
        }

        ///// <summary>
        ///// Add actions which will be executed bofore current action execution
        ///// </summary>
        ///// <param name="action">action</param>
        //public void AddBeforeActionExecutionListener(IListener listener)
        //{
        //    //BeforeListeners.Add(listener);
        //}

        ///// <summary>
        ///// Add actions which will be executed after current action execution
        ///// </summary>
        ///// <param name="action">action</param>
        //public void AddAfterActionExecutionListener(IListener listener)
        //{
        //    //AfterListeners.Add(listener);
        //}


        /// <summary>
        /// Add LAFConfiguration to LAFConfigurationset
        /// </summary>
        /// <param name="lafConfiguration">LAFConfiguration</param>
        public void AddLAFConfiguration(ILAFConfiguration lafConfiguration)
        {
            //ConfigurationSet.LAFConfigurations.Add(lafConfiguration);
            ObjectPool.LoadForLAFConfiguration(lafConfiguration);
        }


        public void RequestExceptionForm(string errorMsg)
        {
            LAFForm form = ObjectPool.GetExceptionForm();

            ApplicationContext.AddParameter(LAF_EXCEPTION, errorMsg);

            form.LoadData();
            form.InitializeComponent();
            form.threadRunning.WaitOne();

            form.RefreshForm();

            /*
            Type type = form.GetType();
            if (type.IsSubclassOf(typeof(LAFForm)))
            {
                (form as LAFForm).LoadData();
                (form as LAFForm).InitializeComponent();
                (form as LAFForm).threadRunning.WaitOne();

                (form as LAFForm).RefreshForm();
                //System.Reflection.MethodInfo method = type.GetMethod(REFRESH_METHOD);
                //method.Invoke(form, null);
            }
            */

            form.Show();
        }

        public void AddLogerPath(string logPath)
        {
            ObjectPool.SetLogerPath(logPath);
        }

        public void LogException(Exception ex)
        {
            ILoggerManager log = ObjectPool.GetLogManager();

            if (ex is AbstractException)
            {
                AbstractException realEx = ex as AbstractException;

                switch (realEx.Level)
                {
                    case FastStructureLogLevel.Debug:
                        log.GetLogger(realEx.GetType().ToString()).Debug(realEx.Message);
                        break;
                    case FastStructureLogLevel.Error:
                        log.GetLogger(realEx.GetType().ToString()).Error(realEx.Message);
                        break;
                    case FastStructureLogLevel.Info:
                        log.GetLogger(realEx.GetType().ToString()).Info(realEx.Message);
                        break;
                    case FastStructureLogLevel.Fatal:
                        log.GetLogger(realEx.GetType().ToString()).Fatal(realEx.Message);
                        break;
                    default:
                        break;
                }
            }
            else 
            {
                log.GetLogger(ex.GetBaseException().ToString()).Error(ex.Message);
            }
        }

        #endregion
    }
}
