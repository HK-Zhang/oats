/*
 * Description:This file contains a interface IContext which is used to implement by the child of class.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Events;
namespace FastStructure.LAF.Context
{
    /// <summary>
    /// Description:This interface supply core functions of IContext 
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Add parameter and data to Context
        /// </summary>
        /// <param name="parameName">paramKey</param>
        /// <param name="data">dataValue</param>
        void AddParameter(string paramName, object data);

        /// <summary>
        /// Set a parameter in Context by paramName
        /// </summary>
        /// <param name="paramName">paramKey</param>
        /// <param name="data">dataValue</param>
        void SetParameter(string paramName, Object data);

        /// <summary>
        /// Get parameter in Context by paramName
        /// </summary>
        /// <param name="paramName">paramKey</param>
        /// <returns></returns>
        object GetParameter(string paramName);

        /// <summary>
        /// Delete parameter by parameName
        /// </summary>
        /// <param name="paramName">paramKey</param>
        void DeleteParameter(string paramName);

        /// <summary>
        /// Add parameter listener to listener
        /// </summary>
        /// <param name="listener">listener</param>
        void AddParameterListeners(IListener listener);

    }
}
