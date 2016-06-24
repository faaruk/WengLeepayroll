using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WengLeePayroll.appcode
{
    public class Common
    {
        public bool DeveloperPc()
        {
            return ((System.Environment.MachineName.ToUpper() == "USER-PC") || (System.Environment.MachineName.ToUpper() == "FARUK-PC"));
        }
    }
}
