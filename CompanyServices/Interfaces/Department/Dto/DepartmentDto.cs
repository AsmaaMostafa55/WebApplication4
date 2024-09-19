using CompanyServices.Interfaces.Employee.Dto;

namespace CompanyServices.Interfaces.Department.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public DateTime createat { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}
