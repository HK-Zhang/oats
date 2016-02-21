using System;
using System.Collections.Generic;
using System.Text;

using FastStructure.LAF.Core.Events;
using FastStructure.LAF.Core.Config;
using FastStructure.FastStructureContext;

namespace FastStructure.Fast.Listeners
{
    public class CaculateListener : AbstractListener
    {
        public override void Receive(IEvent eventItem)
        {
            if (eventItem.GetType().Equals(typeof(ParameterEvent)))
            {
                ParameterEvent pevent = (ParameterEvent)eventItem;

                if (pevent.ParameterName.Equals(EnumContextKey.CaculateMode.ToString())
                    && (pevent.ParameterOperationType == EnumParameterOperationType.UPDATED || pevent.ParameterOperationType == EnumParameterOperationType.CREATED))
                {
                    CaculateContext ctx = FASTContextFactory.CreateCaculateContext(Context);
                    ctx.Result = pevent.ParameterName + "/" + pevent.CurrentValue.ToString();
                }
            }
        }
    }
}
