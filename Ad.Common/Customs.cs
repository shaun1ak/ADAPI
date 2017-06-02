using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Common
{
    public enum CartType : int
    {
        InProcess,
        Complete
    }

    public static class Util
    {
        public const string DefaultUser = "SYSTEM";
    }
}
