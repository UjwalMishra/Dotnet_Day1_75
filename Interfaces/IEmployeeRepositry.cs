using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployee();
        Task<Employee?> GetByIdEmployee(int id);
        Task<List<string>> GetAllDepartmentsEmployee();
        
        
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
    }
}