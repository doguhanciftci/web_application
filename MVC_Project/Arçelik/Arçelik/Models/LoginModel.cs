using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arçelik.Models
{
    public class LoginModel
    {
        public LoginModel(string u, string p)
        {
            Username = u;
            Password = p;
        }

        public LoginModel()
        {

        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
