using EmployeeManagement.DTO;
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
        public async Task<IActionResult> Index(string department = "", string status = "", string search = "")
        {
            var employees = await _employeeService.GetEmployees(department, status, search);

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                TotalEmployees = employees.Count,
                SelectedDepartment = department,
                SelectedStatus = status,
                SearchTerm = search
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee == null) return BadRequest("Employee not found");

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentCount()
        {
            var model = await _employeeService.GetDepartmentCounts();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _employeeService.GetAllDepartments();
            
            return Json(departments);
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto val)
        {
            await _employeeService.CreateEmployee(val);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeDto val)
        {
            var success = await _employeeService.UpdateEmployee(val);
            if (!success) return  BadRequest("Error while updating the User");
            
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _employeeService.DeleteEmployee(id);
            if (!success) return  BadRequest("Error while deleting the User");
            
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null) return  BadRequest("Employee not found");
            
            return Json(employee);
        }
        
    }
}