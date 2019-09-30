using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arçelik.Models
{
    public class Applicant
    {
        public Applicant()
        {
            LoginModel = new LoginModel();
        }
        public static int Count { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        public int Age { get; set; }

        [Required]
        public string Phone { get; set; }

        public string PLocation { get; set; } //preferred location

        public List<SelectListItem> Locations { get; set; }


        public string Pdepartment { get; set; } //preferred department

        public List<SelectListItem> Departments { get; set; }

        public string ExtraInfo { get; set; } // extra information (optional)

        [Required]
        public DateTime AddedOn { get; set; }

        public LoginModel LoginModel { get; set; }
    }
}
