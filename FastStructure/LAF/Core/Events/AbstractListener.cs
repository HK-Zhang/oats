/*
 * Description:This file is define AbstractClass, which implement interface IListener and IContextAware
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */

using System;
using System.Collections.Generic;
using System.Text;
using FastStructure.LAF.Context;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This abstract class is used to supply some core function.
    /// Author: Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public abstract class AbstractListener : IListener, IContextAware
    {
        /// <summary>
        /// Receive listener 
        /// </summary>
        /// <param name="eventItem">eventItem</param>
        public abstract void Receive(IEvent eventItem);

        private IContext m_Context;

        /// <summary>
        /// supply get or set method of  property Context value
        /// </summary>
        public IContext Context
        {
            get
            {
                return m_Context;
            }
            set
            {
                m_Context = value;
            }
        }
    }
}
