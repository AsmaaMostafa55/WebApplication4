




namespace CompanyServices.Interfaces.DepartmentDto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public DateTime CreateAt { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
