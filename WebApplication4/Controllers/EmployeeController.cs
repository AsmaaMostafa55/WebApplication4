using CompanyData.Entities;
using CompanyRepository.interfaces;
using CompanyServices.Interfaces;
using CompanyServices.Interfaces.DepartmentDto;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public IEmployeeService EmployeeService => _employeeService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService
            )
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index(string searchImp)
        {
            //viewBag,ViewData,TempData
            //ViewBag.Message = "Hello From EmployeeIndex (ViewBag)";

            //ViewData["TextMessage"] = "Hello From EmployeeIndex (ViewBag)"; ;
            //TempData["TextMessage"] = "Hello From EmployeeIndex (TempData)";



            IEnumerable<Employee> employees = new List<Employee>();
            if (string.IsNullOrEmpty(searchImp))
                employees = _employeeService.GEtAll();


            else
                employees = EmployeeService.GetEmployeeByName(searchImp);

            return View(employees);


        }
        [HttpGet]
        public IActionResult Create()
        {
            
            //viewBag,ViewData,TempData
            ViewBag.Departments = _departmentService.GetAll();


            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(employee);
            }
            catch (Exception ex) {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(employee);
            }
        } 

        //public IActionResult Details(int? id, string viewName = "Details")
        //{
        //}



    }
}
