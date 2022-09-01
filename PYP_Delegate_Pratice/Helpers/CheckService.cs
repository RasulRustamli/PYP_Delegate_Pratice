using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_Delegate_Pratice.Helpers
{
    public static class CheckService
    {
        public static bool CheckName(string name )
        {
            Regex regexx = new Regex(@"^[A-Z]{1,}[a-z]{2,}\d*$");
            Match match = regexx.Match(name);
           return match.Success;
        }
        public static bool PasswordCheck(string password)
        {
          Regex  regexx = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d@$!%*?&]{8,}");
          Match  match = regexx.Match(password);
            return match.Success;
        }
        public static bool CheckMail(string mail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mail);
            return match.Success;
        }

    }
}
