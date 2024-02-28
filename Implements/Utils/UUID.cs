using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Utils
{
    public static class UUID
    {
        public static string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
