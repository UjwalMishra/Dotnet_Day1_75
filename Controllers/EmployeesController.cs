using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Interfaces;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index(
            string department = "",
            string status = "",
            string search = ""
        )
        {
            var employees = _employeeService.GetEmployees(department, status, search);

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                Departments = _employeeService.GetAllDepartments(),
                TotalEmployees = employees.Count,
                SelectedDepartment = department,
                SelectedStatus = status,
                SearchTerm = search
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
                return BadRequest("Employee not found");

            return View(employee);
        }
        
        [HttpGet]
        public IActionResult DepartmentCount()
        {
            var model = _employeeService.GetDepartmentCounts();
            return View(model);
        }

    }
}