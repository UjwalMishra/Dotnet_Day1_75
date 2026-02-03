using DotnetBasics.Data;
using DotnetBasics.Models;

namespace DotnetBasics.Services
{
    public class EmployeeService
    {
        public List<Employee> GetAll()
        {
            try
            {
                return EmployeeData.Employees;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch employees.", ex);
            }
        }

        public Employee? GetById(int id)
        {
            try
            {
                return EmployeeData.Employees
                    .FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch employee by id.", ex);
            }
        }

        public List<Employee> GetByDepartment(string department)
        {
            try
            {
                return EmployeeData.Employees
                    .Where(e => e.Department == department)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch employees by department.", ex);
            }
        }

        public List<Employee> GetActive(bool isActive)
        {
            try
            {
                return EmployeeData.Employees
                    .Where(e => e.IsActive == isActive)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to fetch active employees.", ex);
            }
        }

        public List<Employee> Search(string name)
        {
            try
            {
                return EmployeeData.Employees
                    .Where(e => e.Name.ToLower().Contains(name.ToLower()))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to search employees.", ex);
            }
        }

        public Dictionary<string, int> CountByDepartment()
        {
            try
            {
                return EmployeeData.Employees
                    .GroupBy(e => e.Department)
                    .ToDictionary(g => g.Key, g => g.Count());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to count employees by department.", ex);
            }
        }
    }
}
