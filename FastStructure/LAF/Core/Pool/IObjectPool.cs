/*
 * Description:This file contains an interface IObjectPool
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;
using FastStructure.LAF.LAFLog;
using FastStructure.LAF.LAFComponents;


namespace FastStructure.LAF.Core.Pool
{
    /// <summary>
    /// Description:This interface define functions of objectpool.
    /// </summary>
    public interface IObjectPool
    {
        LAFForm GetFormInstance(string formId);
        object GetFormData(string formId);
        IAction GetFormAction(string formId);
        LAFForm GetExceptionForm();
        IAction GetExceptionAction();
        IAction GetAction(string actionId);
        IListener[] GetParameterListeners();
        IListener[] GetActionListeners(string actionId, EnumActionListenerOccasion occasion);
        void LoadForLAFConfiguration(ILAFConfiguration lafConfiguration);
        void LoadMessage(string path);
        void SetLogerPath(string path);
        ILoggerManager GetLogManager();
    }
}
