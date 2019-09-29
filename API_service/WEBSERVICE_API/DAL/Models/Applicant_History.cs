using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Applicant_History
    {
        public int H_Applicant_Id { get; set; }
        public int Applicant_Id { get; set; }
        public string H_FName { get; set; }
        public string H_LName { get; set; }
        public int H_Age { get; set; }
        public string H_Phone { get; set; }
        public string H_Extra { get; set; }
        public DateTime H_ModificationDate { get; set; }
        public string H_Username { get; set; }
        public string H_Password { get; set; }
    }
}
