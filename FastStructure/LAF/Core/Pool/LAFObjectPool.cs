/*
 * Description:This file contains a class LAFObjectPool.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

using FastStructure.LAF.Core.Config;
using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Utilities;
using FastStructure.LAF.Context;
using FastStructure.LAF.Exceptions;
using FastStructure.LAF.GenericType;
using FastStructure.LAF.Messages;
using FastStructure.LAF.LAFLog;
using FastStructure.LAF.LAFComponents;

namespace FastStructure.LAF.Core.Pool
{
    /// <summary>
    /// Description:This class implement the function of IObjectPool.
    /// </summary>
    public class LAFObjectPool : IObjectPool
    {
        #region PoolObjects
        Hashtable singletonForms = new Hashtable();
        Hashtable protoTypeForms = new Hashtable();
        Hashtable singletonFormDatas = new Hashtable();
        Hashtable protoTypeFormDatas = new Hashtable();
        Hashtable singletonFormActions = new Hashtable();
        Hashtable protoTypeFormActions = new Hashtable();
        Hashtable singletonActions = new Hashtable();
        Hashtable protoTypeActions = new Hashtable();
        Hashtable singletonParameterListeners = new Hashtable();
        Hashtable singletonActionListeners = new Hashtable();
        Hashtable protoTypeParameterListeners = new Hashtable();
        Hashtable protoTypeActionListeners = new Hashtable();
        LAFForm ExceptionForm = null;
        IAction ExceptionAction = null;
        IContext Context;
        ILoggerManager loggerManager;
        MessageManager m_MsgManger = null;
        #endregion

        #region LockObjects
        object formLock = new object();
        object formDataLock = new object();
        object formActionLock = new object();
        object actionLock = new object();
        object exceptionFromLock = new object();
        object exceptionActionLock = new object();
        object parameterListenersLock = new object();
        object actionListenersLock = new object();
        #endregion

        #region ERROR_MESSAGE
        const string NOT_WINFORM_ERROR_MESSAGE = "Is not windows form subclass";
        const string NOT_CLONE_ERROR_MESSAGE = "Not have Clone method";
        const string NOT_IACTION_MESSAGE = "Is not IAction subclass";
        const string NO_EXPECTED_ERROR = "Not expected error";
        #endregion

        const string CLONE_METHOD = "Clone";
        const string CONTEXT_PROPERTY = "Context";

        private LAFConfigurationSet lafSet = new LAFConfigurationSet();

        #region IObjectPool Members

        private object GetObject(string objKey)
        {
            return null;

        }

        public MessageManager MsgManger
        {
            set
            {
                m_MsgManger = value;
            }
        }

        public IContext ContextInstance
        {
            set
            {
                Context = value;
            }
        }

        public ILoggerManager LoggerManager
        {
            set
            {
                loggerManager = value;
            }
        }

        public void InitialFormData()
        {
            FormItemSet frmSet = lafSet.FormItemSet;


            for (int i = 0; i < frmSet.FormItems.Count; i++)
            {
                object frnData = GetFormData(frmSet.FormItems[i].FormId);
                if (frnData != null)
                {
                    FormContext fctx = FormContextFactory.GetFormContext(Context, frmSet.FormItems[i].FormId);
                    fctx.FormData = frnData;
                }

            }

        }

        public void InitialLoggerManager(string logPath)
        {
            LogItem logItem = lafSet.LogItem;
            string fqtn = logItem.LogDef.LogType;
            LoggerManager = (ILoggerManager)CreateInstance(fqtn);
            loggerManager.ConfigFilePath = logPath;
            //LoggerManager.LogPath = logPath;
            //Type type = logger.GetType();
            //System.Reflection.PropertyInfo pifo = type.GetProperty("LogFilePath");
            //pifo.SetValue(logger, logItem.LogDef.LogPath, null);

        }

        
        /// <summary>
        /// Get form instance from object pool
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        /// <returns>windows form</returns>
        public LAFForm GetFormInstance(string formId)
        {
            if (string.IsNullOrEmpty(formId))
            {
                return null;
            }

            FormItemSet frmSet = lafSet.FormItemSet;
            EnumInstanceScope scope = frmSet.GetFormDef(formId).Scope;
            string fqtn = frmSet.GetFormDef(formId).FormType;

            object form = null;

            lock (formLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (singletonForms.Contains(formId))
                            {
                                return (LAFForm)singletonForms[formId];
                            }
                            else
                            {
                                form = CreateContextInstance(fqtn);
                            }
                            break;
                        case EnumInstanceScope.PROTOTYPE:
                            if (protoTypeForms.Contains(formId))
                            {
                                Type type = protoTypeForms[formId].GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                return (LAFForm)method.Invoke(protoTypeForms[formId], null);
                            }
                            else
                            {
                                form = CreateContextInstance(fqtn);
                                if (!HasCloneMethod(form.GetType()))
                                {
                                    form = null;
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                            }
                            break;
                        case EnumInstanceScope.REQUEST:
                            form = CreateContextInstance(fqtn);
                            break;
                        default:
                            break;
                    }

                    if (IsLAFForm(form.GetType()))
                    {

                        if (scope == EnumInstanceScope.SINGLETON)
                        {
                            (form as LAFForm).Scope = EnumInstanceScope.SINGLETON;
                            singletonForms.Add(formId, form);
                        }
                        else if (scope == EnumInstanceScope.PROTOTYPE)
                        {
                            (form as LAFForm).Scope = EnumInstanceScope.PROTOTYPE;
                            protoTypeForms.Add(formId, form);
                        }

                        return (LAFForm)form;
                    }
                    else
                    {
                        LAFObjectPoolException lex = new LAFObjectPoolException(NOT_WINFORM_ERROR_MESSAGE);
                        throw lex;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }

        }

        /// <summary>
        /// Get form data from object pool
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        /// <returns>the data model object of the corresponding form</returns>
        public object GetFormData(string formId)
        {
            if (string.IsNullOrEmpty(formId))
            {
                return null;
            }

            FormItemSet frmSet = lafSet.FormItemSet;
            EnumInstanceScope scope = lafSet.FormItemSet.GetDataDef(formId).Scope;
            string fqtn = frmSet.GetDataDef(formId).FormDataType;

            if (string.IsNullOrEmpty(fqtn))
            {
                return null;
            }

            lock (formDataLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (singletonFormDatas.Contains(formId))
                            {
                                return singletonFormDatas[formId];
                            }
                            else
                            {
                                object formData = CreateContextInstance(fqtn);
                                singletonFormDatas.Add(formId, formData);
                                return formData;
                            }
                        case EnumInstanceScope.PROTOTYPE:
                            if (protoTypeFormDatas.Contains(formId))
                            {
                                Type type = protoTypeFormDatas[formId].GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                return method.Invoke(protoTypeFormDatas[formId], null);
                            }
                            else
                            {
                                object formData = CreateContextInstance(fqtn);
                                if (!HasCloneMethod(formData.GetType()))
                                {
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                                else
                                {
                                    protoTypeFormDatas.Add(formId, formData);
                                    return formData;
                                }
                            }
                        case EnumInstanceScope.REQUEST:
                            return CreateContextInstance(fqtn);
                        default:
                            break;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }

            return null;

        }

        /// <summary>
        /// Get from action from object pool
        /// </summary>
        /// <param name="formId">An identifier attribute of the specific form</param>
        /// <returns>The controller object of the corresponding form</returns>
        public IAction GetFormAction(string formId)
        {
            if (string.IsNullOrEmpty(formId))
            {
                return null;
            }

            FormItemSet frmSet = lafSet.FormItemSet;
            string fqtn = frmSet.GetActionDef(formId).ActionType;
            EnumInstanceScope scope = frmSet.GetActionDef(formId).Scope;

            if (string.IsNullOrEmpty(fqtn))
            {
                return null;
            }

            object action = null;

            lock (formActionLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (singletonFormActions.Contains(formId))
                            {
                                return (IAction)singletonFormActions[formId];
                            }
                            else
                            {
                                action = CreateContextInstance(fqtn);
                            }
                            break;
                        case EnumInstanceScope.PROTOTYPE:
                            if (protoTypeFormActions.Contains(formId))
                            {
                                Type type = protoTypeFormActions[formId].GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                method.Invoke(protoTypeFormActions[formId], null);
                            }
                            else
                            {
                                action = CreateContextInstance(fqtn);
                                if (!HasCloneMethod(action.GetType()))
                                {
                                    action = null;
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                            }
                            break;
                        case EnumInstanceScope.REQUEST:
                            action = CreateContextInstance(fqtn);
                            break;
                        default:
                            break;
                    }

                    if (IsIAction(action.GetType()))
                    {

                        if (scope == EnumInstanceScope.SINGLETON)
                        {
                            singletonFormActions.Add(formId, action);
                        }
                        else if (scope == EnumInstanceScope.PROTOTYPE)
                        {
                            protoTypeFormActions.Add(formId, action);
                        }

                        return (IAction)action;
                    }
                    else
                    {
                        LAFObjectPoolException lex = new LAFObjectPoolException(NOT_IACTION_MESSAGE);
                        throw lex;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }

        }

        /// <summary>
        /// Get Exception Form object pool
        /// </summary>
        /// <returns>Exception Form</returns>
        public LAFForm GetExceptionForm()
        {
            ExceptionFormItem exceptionForm = lafSet.ExceptionFormItem;
            string fqtn = exceptionForm.FormDef.FormType;
            EnumInstanceScope scope = exceptionForm.FormDef.Scope;

            lock (exceptionFromLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (ExceptionForm != null)
                            {
                                return ExceptionForm;
                            }
                            else
                            {
                                ExceptionForm = (LAFForm)CreateContextInstance(fqtn);
                                ExceptionForm.Scope = EnumInstanceScope.SINGLETON;
                            }
                            break;
                        case EnumInstanceScope.PROTOTYPE:
                            if (ExceptionForm != null)
                            {
                                Type type = ExceptionForm.GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                return (LAFForm)method.Invoke(ExceptionForm, null);
                            }
                            else
                            {
                                ExceptionForm = (LAFForm)CreateContextInstance(fqtn);
                                ExceptionForm.Scope = EnumInstanceScope.PROTOTYPE;
                                if (!HasCloneMethod(ExceptionForm.GetType()))
                                {
                                    ExceptionForm = null;
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                            }
                            break;
                        case EnumInstanceScope.REQUEST:
                            ExceptionForm = (LAFForm)CreateContextInstance(fqtn);
                            break;
                        default:
                            break;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }


            return ExceptionForm;

        }

        /// <summary>
        /// Get exception action from object pool
        /// </summary>
        /// <returns>exception action</returns>
        public IAction GetExceptionAction()
        {
            ExceptionFormItem exceptionForm = lafSet.ExceptionFormItem;
            string fqtn = exceptionForm.ActionDef.ActionType;
            EnumInstanceScope scope = exceptionForm.ActionDef.Scope;

            if (string.IsNullOrEmpty(fqtn))
            {
                return null;
            }

            lock (exceptionActionLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (ExceptionAction != null)
                            {
                                return ExceptionAction;
                            }
                            else
                            {
                                ExceptionAction = (IAction)CreateContextInstance(fqtn);
                            }
                            break;
                        case EnumInstanceScope.PROTOTYPE:
                            if (ExceptionAction != null)
                            {
                                Type type = ExceptionAction.GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                return (IAction)method.Invoke(ExceptionAction, null);
                            }
                            else
                            {
                                ExceptionAction = (IAction)CreateContextInstance(fqtn);
                                if (!HasCloneMethod(ExceptionAction.GetType()))
                                {
                                    ExceptionAction = null;
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                            }
                            break;
                        case EnumInstanceScope.REQUEST:
                            ExceptionAction = (IAction)CreateContextInstance(fqtn);
                            break;
                        default:
                            break;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }


            return ExceptionAction;
        }

        /// <summary>
        /// Get Action from object pool
        /// </summary>
        /// <param name="actionId">An identifier attribute of the specific action</param>
        /// <returns>action object implement IAction</returns>
        public IAction GetAction(string actionId)
        {
            if (string.IsNullOrEmpty(actionId))
            {
                return null;
            }

            EnumInstanceScope scope = lafSet.ActionItemSet.GetScope(actionId);
            string fqtn = lafSet.ActionItemSet.GetActionType(actionId);
            object action = null;

            lock (actionLock)
            {
                try
                {
                    switch (scope)
                    {
                        case EnumInstanceScope.SINGLETON:
                            if (singletonActions.Contains(actionId))
                            {
                                return (IAction)singletonActions[actionId];
                            }
                            else
                            {
                                action = CreateContextInstance(fqtn);
                            }
                            break;
                        case EnumInstanceScope.PROTOTYPE:
                            if (protoTypeActions.Contains(actionId))
                            {
                                Type type = protoTypeActions[actionId].GetType();
                                System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                method.Invoke(protoTypeActions[actionId], null);
                            }
                            else
                            {
                                action = CreateContextInstance(fqtn);
                                if (!HasCloneMethod(action.GetType()))
                                {
                                    action = null;
                                    LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                    throw lex;
                                }
                            }
                            break;
                        case EnumInstanceScope.REQUEST:
                            action = CreateContextInstance(fqtn);
                            break;
                        default:
                            break;
                    }

                    if (IsIAction(action.GetType()))
                    {
                        if (scope == EnumInstanceScope.SINGLETON)
                        {
                            singletonActions.Add(actionId, action);
                        }
                        else if (scope == EnumInstanceScope.PROTOTYPE)
                        {
                            protoTypeActions.Add(actionId, action);
                        }

                        return (IAction)action;
                    }
                    else
                    {
                        LAFObjectPoolException lex = new LAFObjectPoolException(NOT_IACTION_MESSAGE);
                        throw lex;
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }

        }

        /// <summary>
        /// Get Parameter Listeners
        /// </summary>
        /// <returns>An array of Parameter Listeners</returns>
        public IListener[] GetParameterListeners()
        {
            ArrayList<ParameterListenerItem> ParameterListeners = lafSet.ParameterListenerItemSet.ParameterListeners;

            IListener[] listeners = new IListener[ParameterListeners.Count];

            lock (parameterListenersLock)
            {
                try
                {
                    for (int i = 0; i < ParameterListeners.Count; i++)
                    {
                        string fqtn = ParameterListeners[i].ListenerType;
                        EnumInstanceScope scope = ParameterListeners[i].Scope;

                        switch (scope)
                        {
                            case EnumInstanceScope.SINGLETON:
                                if (singletonParameterListeners.Contains(fqtn))
                                {
                                    listeners[i] = (IListener)singletonParameterListeners[fqtn];
                                }
                                else
                                {
                                    object listener = CreateContextInstance(fqtn);
                                    singletonParameterListeners.Add(fqtn, listener);
                                    listeners[i] = (IListener)listener;
                                }
                                break;
                            case EnumInstanceScope.PROTOTYPE:
                                if (protoTypeParameterListeners.Contains(fqtn))
                                {
                                    Type type = protoTypeParameterListeners[fqtn].GetType();
                                    System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                    listeners[i] = (IListener)method.Invoke(protoTypeParameterListeners[fqtn], null);
                                }
                                else
                                {
                                    object listener = CreateContextInstance(fqtn);
                                    if (!HasCloneMethod(listener.GetType()))
                                    {
                                        LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                        throw lex;
                                    }
                                    else
                                    {
                                        protoTypeParameterListeners.Add(fqtn, listener);
                                        listeners[i] = (IListener)listener;
                                    }
                                }
                                break;
                            case EnumInstanceScope.REQUEST:
                                listeners[i] = (IListener)CreateContextInstance(fqtn);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }


            return listeners;

        }

        /// <summary>
        /// Get Action Listeners
        /// </summary>
        /// <param name="actionId">An identifier attribute of the specific action</param>
        /// <param name="occasion">When Listeners will be invoked </param>
        /// <returns>An array of Action Listeners</returns>
        public IListener[] GetActionListeners(string actionId, EnumActionListenerOccasion occasion)
        {
            if (string.IsNullOrEmpty(actionId))
            {
                return null;
            }

            ArrayList<ActionListenerItem> actionListeners = lafSet.ActionListenerItemSet.GetActionTypes(occasion);
            string assembly = string.Empty;
            IListener[] listeners = new IListener[actionListeners.Count];


            lock (actionListenersLock)
            {
                try
                {
                    for (int i = 0; i < actionListeners.Count; i++)
                    {
                        if (actionListeners[i].ActionId != actionId)
                        {
                            continue;
                        }
                        string fqtn = actionListeners[i].ListenerType;
                        EnumInstanceScope scope = actionListeners[i].Scope;

                        switch (scope)
                        {
                            case EnumInstanceScope.SINGLETON:
                                if (singletonActionListeners.Contains(fqtn))
                                {
                                    listeners[i] = (IListener)singletonActionListeners[fqtn];
                                }
                                else
                                {
                                    object listener = CreateContextInstance(fqtn);
                                    singletonActionListeners.Add(fqtn, listener);
                                    listeners[i] = (IListener)listener;
                                }
                                break;
                            case EnumInstanceScope.PROTOTYPE:
                                if (protoTypeActionListeners.Contains(fqtn))
                                {
                                    Type type = protoTypeActionListeners[fqtn].GetType();
                                    System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);
                                    listeners[i] = (IListener)method.Invoke(protoTypeActionListeners[fqtn], null);
                                }
                                else
                                {
                                    object listener = CreateContextInstance(fqtn);
                                    if (!HasCloneMethod(listener.GetType()))
                                    {
                                        LAFObjectPoolException lex = new LAFObjectPoolException(NOT_CLONE_ERROR_MESSAGE);
                                        throw lex;
                                    }
                                    else
                                    {
                                        protoTypeActionListeners.Add(fqtn, listener);
                                        listeners[i] = (IListener)listener;
                                    }
                                }
                                break;
                            case EnumInstanceScope.REQUEST:
                                listeners[i] = (IListener)CreateContextInstance(fqtn);
                                break;
                            default:
                                break;
                        }

                    }
                }
                catch (LAFObjectPoolException lex)
                {
                    throw lex;
                }
                catch (Exception)
                {

                    throw new LAFObjectPoolException(NO_EXPECTED_ERROR);
                }
            }

            int cnt = 0;

            foreach (IListener item in listeners)
            {
                if (item != null)
                {
                    cnt++;
                }
            }

            IListener[] result = new IListener[cnt];
            int index = 0;
            foreach (IListener item in listeners)
            {
                if (item != null)
                {
                    result[index] = item;
                    index++;
                }
            }

            //return listeners;
            return result;


        }

        #endregion


        #region Utlity
        /// <summary>
        /// Check object inherit from Windows.Form or not
        /// </summary>
        /// <param name="type">the type of object</param>
        /// <returns>if the object inherit from Windows.Form,return true</returns>
        private bool IsWinForm(Type type)
        {
            //Assembly ass = Assembly.LoadFrom(@assembly);
            //Type type = ass.GetType(fqtn);
            Type winFormType = typeof(System.Windows.Forms.Form);
            return type.IsSubclassOf(winFormType);
        }

        /// <summary>
        /// Check object inherit from LAFForm or not
        /// </summary>
        /// <param name="type">the type of object</param>
        /// <returns>if the object inherit from LAFForm,return true</returns>
        private bool IsLAFForm(Type type)
        {
            return type.IsSubclassOf(typeof(LAFForm));
        }


        /// <summary>
        /// Check object implement IAction or not
        /// </summary>
        /// <param name="type">the type of object</param>
        /// <returns>if the object implement IAction,return true</returns>
        private bool IsIAction(Type type)
        {
            Type iActionType = typeof(IAction);
            //return true;
            return type.GetInterface("IAction", true) != null;
            //return type.IsSubclassOf(iActionType);
        }

        /// <summary>
        /// Check object implement IContextAware or not
        /// </summary>
        /// <param name="type">the type of object</param>
        /// <returns>if the object implement IContextAware,return true</returns>
        private bool IsIContextAware(Type type)
        {
            Type iActionType = typeof(IContextAware);

            return type.GetInterface("IContextAware", true) != null;
        }

        /// <summary>
        /// Check the object contains Clone method or not
        /// </summary>
        /// <param name="type">the type of object</param>
        /// <returns>If the object contains Clone method,return true</returns>
        private bool HasCloneMethod(Type type)
        {
            System.Reflection.MethodInfo method = type.GetMethod(CLONE_METHOD);

            if (method == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Set context value of  object
        /// </summary>
        /// <param name="obj">target object</param>
        /// <returns>the object with context value</returns>
        private object SetContext(object obj)
        {
            Type type = obj.GetType();
            if (IsIContextAware(type))
            {
                System.Reflection.PropertyInfo pifo = type.GetProperty(CONTEXT_PROPERTY);
                pifo.SetValue(obj, this.Context, null);

            }

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private object SetMessage(object obj)
        {
            Type type = obj.GetType();


            foreach (PropertyInfo pifo in type.GetProperties())
            {
                if (pifo.PropertyType.ToString() == typeof(MessageManager).ToString())
                {
                    pifo.SetValue(obj, this.m_MsgManger, null);
                    break;
                }
            }

            return obj;
        }

        private object SetLogger(object obj)
        {
            Type type = obj.GetType();


            foreach (PropertyInfo pifo in type.GetProperties())
            {

                if (pifo.PropertyType.ToString() == typeof(ILoggerManager).ToString())
                {
                    pifo.SetValue(obj, this.loggerManager, null);
                    break;
                }
            }

            return obj;

        }

        /// <summary>
        /// creat instance by fqtn
        /// </summary>
        /// <param name="fqtn">fully qualified type name</param>
        /// <returns>object</returns>
        private object CreateContextInstance(string fqtn)
        {
            string[] strs = fqtn.Split(",".ToCharArray());

            string assembly = strs[2] + "\\" + strs[1] + ".dll";
            if (!File.Exists(assembly))
            {
                assembly = strs[2] + "\\" + strs[1] + ".exe";
            }
            string fullName = strs[0];

            object obj = ReflectUtil.CreateInstance(assembly, fullName);
            return SetLogger(SetMessage(SetContext(obj)));

        }

        private object CreateInstance(string fqtn)
        {
            string[] strs = fqtn.Split(",".ToCharArray());

            string assembly = strs[2] + "\\" + strs[1] + ".dll";
            if (!File.Exists(assembly))
            {
                assembly = strs[2] + "\\" + strs[1] + ".exe";
            }
            string fullName = strs[0];

            return ReflectUtil.CreateInstance(assembly, fullName);

        }


        public void LoadForLAFConfiguration(ILAFConfiguration lafConfiguration)
        {
            lafSet.LAFConfigurations.Add(lafConfiguration);
        }


        public void LoadMessage(string path)
        {
            m_MsgManger.LoadMessageSet(path);
        }


        public void SetLogerPath(string path)
        {
            //logger.LogPath = path;
        }

        public ILoggerManager GetLogManager()
        {
            return loggerManager;
        }

        #endregion
    }
}
