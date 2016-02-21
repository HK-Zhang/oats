using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

using FastStructure.LAF.Core.LAFActions;
using FastStructure.LAF.Exceptions;

namespace FastStructure.LAF.Core.Utilities
{
    public class ReflectUtil
    {
        public static object CreateInstance(string assembly, string fqtn)
        {

            try
            {
                Assembly ass = Assembly.LoadFrom(assembly);
                Type type = ass.GetType(fqtn);
                return Activator.CreateInstance(type);
            }
            catch (Exception)
            {

                throw new LAFObjectPoolException("Cant find this class.");
            }
        }

    }
}
