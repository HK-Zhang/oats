/*
 * Description:This file contains a interface ILAFBuilder to build ApplicationFramework.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.LAFLog;

namespace FastStructure.LAF.Core
{
    /// <summary>
    /// This interface define processes to build ApplicationFramework.
    /// First Step:LoadConfiguration
    /// Second Step:BuildApplicationContext
    /// Third Step:BuildObjectPool
    /// Forth Step:InitializeParameterListeners
    /// Fifth Step:RetrieveApplicationFramework
    /// </summary>
    public interface ILAFBuilder
    {
        void Initialize();
        void LoadConfiguration(string filePath);
        void BuildApplicationContext();
        void BuildMessage(string path);
        void BuildObjectPool(string logPath);
        void InitializeParameterListeners();
        IApplicationFramework RetrieveApplicationFramework();
    }
}
