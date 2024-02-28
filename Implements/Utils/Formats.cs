using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Implements.Utils
{
    public static class Formats
    {
        public static bool IsEmail(string email)
        {
            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        public static bool IsMobile(string mobile)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            Match match = regex.Match(mobile);
            return match.Success;
        }
    }
}
