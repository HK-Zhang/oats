using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Validation
{
    public interface IValidatable
    {
        ValidateMessage Validate();
    }
}
