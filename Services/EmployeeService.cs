using EmployeeManagement.DTO;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        private static EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
                IsActive = employee.IsActive
            };
        }

        public async Task<List<EmployeeDto>> GetEmployees(
            string department,
            string status,
            string search
        )
        {
            var employees = await _repository.GetAllEmployee();
            var query = employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(department))
                query = query.Where(e => e.Department == department);

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(e => e.IsActive == (status == "Active"));

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(e => e.Name.Contains(search));

            return query.Select(MapToDto).ToList();
        }

        public async Task<EmployeeDto?> GetById(int id)
        {
            var employee = await _repository.GetByIdEmployee(id);
            return employee == null ? null : MapToDto(employee);
        }

        public async Task<List<string>> GetAllDepartments()
        {
            return await _repository.GetAllDepartmentsEmployee();
        }

        public async Task<List<DepartmentCountViewModel>> GetDepartmentCounts()
        {
            var employees = await _repository.GetAllEmployee();

            return employees
                .GroupBy(e => e.Department)
                .Select(g => new DepartmentCountViewModel
                {
                    Department = g.Key,
                    TotalEmployees = g.Count()
                })
                .ToList();
        }
        
        public async Task CreateEmployee(CreateEmployeeDto val)
        {
            var employee = new Employee
            {
                Name = val.Name,
                Department = val.Department,
                Email = val.Email,
                IsActive = val.IsActive
            };

            await _repository.AddEmployee(employee);
        }

        public async Task<bool> UpdateEmployee(UpdateEmployeeDto val)
        {
            var employee = await _repository.GetByIdEmployee(val.Id);
            if (employee == null) return false;

            employee.Name = val.Name;
            employee.Department = val.Department;
            employee.Email = val.Email;
            employee.IsActive = val.IsActive;

            await _repository.UpdateEmployee(employee);
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _repository.GetByIdEmployee(id);
            if (employee == null) return false;

            await _repository.DeleteEmployee(employee);
            return true;
        }

    }
}
