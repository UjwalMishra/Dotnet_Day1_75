using Microsoft.AspNetCore.Mvc;
using DotnetBasics.Services;

namespace DotnetBasics.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // /Employees
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View("Index", employees);
        }

        // /Employees/Details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // /Employees/ByDepartment?department=Engineering
        [HttpGet]
        public IActionResult ByDepartment(string department)
        {
            var employees = _employeeService.GetByDepartment(department);
            return View("Index", employees);
        }

        // /Employees/ByStatus?isActive=true
        [HttpGet]
        public IActionResult ByStatus(bool isActive)
        {
            var employees = _employeeService.GetActive(isActive);
            return View("Index", employees);
        }

        // /Employees/Search?name=Amit
        [HttpGet]
        public IActionResult Search(string name)
        {
            var employees = _employeeService.Search(name);
            return View("Index", employees);
        }
        
        // /Employees/DepartmentCount
        [HttpGet]
        public IActionResult DepartmentCount()
        {
            var result = _employeeService.CountByDepartment();
            return View(result);
        }

    }
}