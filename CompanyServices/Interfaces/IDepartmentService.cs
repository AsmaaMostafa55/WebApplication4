
namespace CompanyServices.Interfaces.DepartmentDto
{
    public interface IDepartmentService
    {
        Department GetById(int? id);
        IEnumerable<Department> GetAll();
        void Add (Department department);
        void Update (Department department);
        void Delete (Department department);
    }
}
