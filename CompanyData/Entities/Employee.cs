using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Entities
{
    public class Employee:BaseEntity
    {
      
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string phonenumber { get; set; }
        public DateTime hiringdate { get; set; }
        public string imageurl { get; set; }


        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
