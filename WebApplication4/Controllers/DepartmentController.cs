using CompanyData.Entities;
using CompanyRepository.interfaces;
using CompanyServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var deparments = _departmentService.GetAll();
            TempData.Keep("TextMessage");
            return View(deparments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {



            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    TempData["TextMessage"] = "Hello From EmployeeIndex (TempData)";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(department);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
        }

        public IActionResult Details(int? id,string ViewName="Details")
        {

            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return RedirectToAction("NotFoundPage", null, "Home");
            }
            return View(ViewName, department);
        }

        [HttpGet]
        public IActionResult Update(int? id) 
        { 
            //var department=_departmentService.GetById(id);
            //if (department == null)
            //    return RedirectToAction("NotFoundPage", null, "Home");

            return Details(id,"Update");
        }
        [HttpPost]
        public IActionResult Update(int? id,Department department) 
        {
        if ( department.id !=id.Value)
            
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));
        
        }


     
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }

    }

}

