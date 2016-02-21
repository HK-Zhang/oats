/*
 * Description:This file contains a EventFactroy,which create instance of IEvent
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Core.Config;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This EventFactory supply to create instance method
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class EventFactroy
    {
        /// <summary>
        /// Create IEvent type instance
        /// </summary>
        /// <param name="paramterName">parameterName</param>
        /// <param name="parameterOperationType">parameterOperationType</param>
        /// <returns></returns>
        public static ParameterEvent CreateParameterEvent(string paramterName, EnumParameterOperationType parameterOperationType, object previousValue, object currentValue)
        {
            ParameterEvent pevent = new ParameterEvent(paramterName, parameterOperationType);
            pevent.PreviousValue = previousValue;
            pevent.CurrentValue = currentValue;
            return pevent;
        }
    }
}
