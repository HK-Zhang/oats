/*
 * Description:This file contains a interface IContextParameterListener which is used to implement by the child of class.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Context
{
    /// <summary>
    /// Description:This interface define some core function ,which implement interface IContextAwar
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface IContextParameterListener : IContextAware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameName">parameName</param>
        /// <param name="type">Enum type</param>
        void Invoke(string parameName, EnumParameterOperationType type);
    }
}
