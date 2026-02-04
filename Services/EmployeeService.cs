using EmployeeManagement.Data;
using EmployeeManagement.DTO;
using EmployeeManagement.Interfaces;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
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

        public List<EmployeeDto> GetEmployees(
            string department,
            string status,
            string search
        )
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(department))
            {
                query = query.Where(e =>
                    e.Department.Equals(department));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                bool isActive = status == "Active";
                query = query.Where(e => e.IsActive == isActive);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e =>
                    e.Name.Contains(search));
            }

            return query
                .AsNoTracking()
                .Select(MapToDto)
                .ToList();
        }

        public EmployeeDto? GetById(int id)
        {
            return _context.Employees
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(MapToDto)
                .FirstOrDefault();
        }
        
        public List<DepartmentCountViewModel> GetDepartmentCounts()
        {
            return _context.Employees
                .AsNoTracking()
                .GroupBy(e => e.Department)
                .Select(g => new DepartmentCountViewModel
                {
                    Department = g.Key,
                    TotalEmployees = g.Count()
                })
                .ToList();
        }
        
        public List<string> GetAllDepartments()
        {
            return _context.Employees
                .AsNoTracking()
                .Select(e => e.Department)
                .Distinct()
                .ToList();
        }

    }
}