using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arçelik.Models
{
    public class Offer
    {
        public int Department_Id { get; set; }

        public string Department_Name { get; set; }

        public int Location_Id { get; set; }

        public string Location_Name { get; set; }

        public string Company_Name { get; set; }

        public string Address { get; set; }
    }
}
