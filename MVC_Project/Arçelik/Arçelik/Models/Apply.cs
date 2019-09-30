using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arçelik.Models
{
    public class Apply
    {
        public int Id { get; set; }

        public int Applicant_Id { get; set; }

        public int Department_Id { get; set; }

        public DateTime ApplyDate { get; set; }
    }
}
