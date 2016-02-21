/*
 * Description:This file contains a class BeforeActionExecuteEvent to supply some core function..
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Events
{
    /// <summary>
    /// Description:This BeforeActionExecuteEvent class is inherit abstract class AbstractEvent.
    /// Author: Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public class BeforeActionExecuteEvent : AbstractEvent
    {
        private string actionID;

        public string ActionID
        {
            get { return actionID; }
            set { actionID = value; }
        }
	
    }
}
