/*
 * Description:This file is define Abstract class ,used to supply some core function for invoke it
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This abstract class is supply some core function. 
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public abstract class AbstractEvent : IEvent
    {
        /// <summary>
        /// supply get or set method of send property
        /// </summary>
        public object Sender
        {
            get
            {
                return Sender;
            }
            set
            {
                Sender = value;
            }
        }

    }
}
