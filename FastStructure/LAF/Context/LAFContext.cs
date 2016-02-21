/*
 * Description:This file contains a class LAFContext to impelment interface IContext.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using FastStructure.LAF.Core.Pool;
using FastStructure.LAF.Core.Config;
using FastStructure.LAF.GenericType;
using FastStructure.LAF.Core.Events;

namespace FastStructure.LAF.Context
{
    /// <summary>
    /// Description:This class supply LAFContext core functions,which implement IContext
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class LAFContext : IContext
    {
        private ArrayList<IListener> parameterListeners;
        private const string ERROR_NOT_EXIST_MSG = "The key is not exist";
        private const string ERROR_EXIST_MSG = "The key is exist";
        private Dictionary<string, object> dtyContext;

        #region constitutor
        /// <summary>
        /// Constructor of LAFContext. Create an data collection instance
        /// to hold the variables.
        /// </summary>
        public LAFContext()
        {
            dtyContext = new Dictionary<string, object>();
            parameterListeners = new ArrayList<IListener>();
        }
        #endregion

        #region Add keyName and objectValue to Context
        //KeyValuePair<string,object>
        /// <summary>
        /// Add parameterKey and object data to Context
        /// </summary>
        /// <param name="paramName">keyName</param>
        /// <param name="data">objectValue</param>
        public void AddParameter(string paramName, object data)
        {
            if (dtyContext.ContainsKey(paramName))
            {
                throw new ArgumentException(ERROR_EXIST_MSG);
            }
            try
            {
                //add the key and data to Context
                dtyContext.Add(paramName, data);
                ParameterEvent pe = EventFactroy.CreateParameterEvent(paramName, EnumParameterOperationType.CREATED, null, data);
                foreach (IListener listener in parameterListeners)
                {
                    //receive create listener action
                    listener.Receive(pe);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region Set keyName and objectValue in Context
        /// <summary>
        /// Set object data in context by keyName
        /// </summary>
        /// <param name="paramName">keyName</param>
        /// <param name="data">value</param>
        public void SetParameter(string paramName, object data)
        {
            if (dtyContext.Count == 0 || !dtyContext.ContainsKey(paramName))
            {
                AddParameter(paramName, data);
            }
            else
            {
                try
                {
                    //receive listener
                    ParameterEvent pe = EventFactroy.CreateParameterEvent(paramName, EnumParameterOperationType.UPDATED, dtyContext[paramName], data);

                    //set data by paramName
                    dtyContext[paramName] = data;

                    foreach (IListener listener in parameterListeners)
                    {
                        //receive update listener action
                        listener.Receive(pe);
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
        #endregion

        #region Get objectValue from Context by keyName
        /// <summary>
        /// Get object data from Context by keyName
        /// </summary>
        /// <param name="paramName">keyName</param>
        /// <returns>value</returns>
        public object GetParameter(string paramName)
        {
            string keyName = paramName;
            object returnObjectValue;
            if (keyName == null || !dtyContext.ContainsKey(keyName))
            {
                return null;
            }
            else
            {
                returnObjectValue = dtyContext[keyName];
            }
            return returnObjectValue;
        }
        #endregion

        #region Delete keyName and objectValue from Context by keyName
        /// <summary>
        /// Delete keyName and objectValue from Context
        /// </summary>
        /// <param name="paramName">keyName</param>
        public void DeleteParameter(string paramName)
        {
            string keyName = paramName;
            if (keyName == null)
            {
                return;
            }
            else
            {
                try
                {
                    ParameterEvent pe = EventFactroy.CreateParameterEvent(paramName, EnumParameterOperationType.REMOVED, dtyContext[keyName], null);

                    foreach (IListener listener in parameterListeners)
                    {
                        //receive remove listener action
                        listener.Receive(pe);
                    }

                    //remove key and data by key
                    dtyContext.Remove(keyName);
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException(ex.Message);
                }
            }
        }
        #endregion

        /// <summary>
        /// Get pooledObject from LAFObjectPool
        /// </summary>
        /// <param name="objId">objectId</param>
        //public object GetPooledObject(string objId)
        //{
        //should invoke Interface
        //LAFObjectPool poolObject = new LAFObjectPool();
        //return poolObject.Get(objId);
        //}

        #region IContext Members
        /// <summary>
        /// Add Parameterlistener to Context
        /// </summary>
        /// <param name="listener">listener</param>
        public void AddParameterListeners(IListener listener)
        {
            parameterListeners.Add(listener);
        }
        #endregion
    }
}
