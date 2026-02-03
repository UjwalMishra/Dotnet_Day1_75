using DotnetBasics.Data;
using DotnetBasics.Models;

namespace DotnetBasics.Services
{
    public class EmployeeService
    {
        public List<Employee> GetAll()
        {
            return EmployeeData.Employees;
        }

        public Employee? GetById(int id)
        {
            return EmployeeData.Employees
                .FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetByDepartment(string department)
        {
            return EmployeeData.Employees
                .Where(e => e.Department == department)
                .ToList();
        }

        public List<Employee> GetActive(bool isActive)
        {
            return EmployeeData.Employees
                .Where(e => e.IsActive == isActive)
                .ToList();
        }

        public List<Employee> Search(string name)
        {
            return EmployeeData.Employees
                .Where(e => e.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
        
        public Dictionary<string, int> CountByDepartment()
        {
            return EmployeeData.Employees
                .GroupBy(e => e.Department)
                .ToDictionary(g => g.Key, g => g.Count());
        }

    }
}