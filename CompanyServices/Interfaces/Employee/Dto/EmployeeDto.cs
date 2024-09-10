
namespace CompanyServices.Interfaces.DepartmentDto
{
    public class Employee
    {
       //
       public Department Department { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string phonenumber { get; set; }
        public DateTime hiringdate { get; set; }
        public string imageurl { get; set; }

        public DateTime CreateAt { get; set; }
       
        public int? DepartmentId { get; set; }
    }
}
