using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class DAL_MyApplication
    {
        public int Apply_Id { get; set; }

        public string Department_Name { get; set; }

        public string Location_Name { get; set; }

        public string Company_Name { get; set; }

        public DateTime Application_Date { get; set; }

        public string Address { get; set; }
    }
}
