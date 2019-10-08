using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class DAL_Applicant
    {
        public int Id { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string ExtraInfo { get; set; } 

        public DateTime AddedOn { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
