
using CompanyServices.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Http;
namespace CompanyServices.Interfaces.Employee.Dto
{
    public class EmployeeDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string phonenumber { get; set; }
        public DateTime hiringdate { get; set; }
        public IFormFile Image { get; set; }

        public string? ImageUrl { get; set; }
        public DateTime createat { get; set; }

        public DepartmentDto? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
