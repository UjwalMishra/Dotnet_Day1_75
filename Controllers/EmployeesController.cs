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

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var employees = _employeeService.GetAll();
                return View("Index", employees);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var employee = _employeeService.GetById(id);

                if (employee == null)
                    return NotFound();

                return View(employee);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult ByDepartment(string department)
        {
            try
            {
                var employees = _employeeService.GetByDepartment(department);
                return View("Index", employees);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult ByStatus(bool isActive)
        {
            try
            {
                var employees = _employeeService.GetActive(isActive);
                return View("Index", employees);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Search(string name)
        {
            try
            {
                var employees = _employeeService.Search(name);
                return View("Index", employees);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult DepartmentCount()
        {
            try
            {
                var result = _employeeService.CountByDepartment();
                return View(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
