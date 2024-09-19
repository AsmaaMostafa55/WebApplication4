using CompanyServices.Interfaces.Department.Dto;
namespace CompanyServices.Interfaces.Department.Dto
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add (DepartmentDto department);
        void Update (DepartmentDto department);
        void Delete (DepartmentDto department);
    }
}
