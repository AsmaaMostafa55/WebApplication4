using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Entities
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime createdat { get; set; } = DateTime.Now;
        public bool isdeleted { get; set; }
    }
}
