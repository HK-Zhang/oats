/*
 * Description:This file contains a interface ILAFConfiguration which is used to implement by the child of class.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Exceptions;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This interface is used to define all property which are must be implemented
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface ILAFConfiguration
    {
        /// <summary>
        /// Get or set the value of property ExceptionFormItem
        /// </summary>
        ExceptionFormItem ExceptionFormItem
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the value of property ActionItemSet
        /// </summary>
        ActionItemSet ActionItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the value of property ParameterListenerItemSet
        /// </summary>
        ParameterListenerItemSet ParameterListenerItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the value of property FormItemSet
        /// </summary>
        FormItemSet FormItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the value of property ActionListenerItemSet
        /// </summary>
        ActionListenerItemSet ActionListenerItemSet
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the value of property LogItem
        /// </summary>
        LogItem LogItem
        {
            get;
            set;
        }
    }
}
