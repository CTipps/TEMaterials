using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Security
{
    public class ResetPassword
    {
        public string ResetCode {get; set;}
        public string NewPassword { get; set; }

    }
}
