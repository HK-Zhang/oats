/*
 * Description:This file contains a interface IApplicationFramework.
 * Author: hzhang
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// This interface define core functions of framework
    /// </summary>
    public interface IApplicationFramework
    {

        void RequestForm(string formId);
        DialogResult RequestDialog(string formId);
        object GetFormData(string formId);
        void RequestFormAction(string formId);
        void RequestGlobalAction(string actionId);
        void RequestExceptionForm(string errorMsg);
        //void AddBeforeActionExecutionListener(IListener listener);
        //void AddAfterActionExecutionListener(IListener listener);
        void AddLAFConfiguration(ILAFConfiguration lafConfiguration);
        void AddLogerPath(string logPath);
        void LogException(Exception ex);

    }
}
