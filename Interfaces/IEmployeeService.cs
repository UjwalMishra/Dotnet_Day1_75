using EmployeeManagement.DTO;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees(
            string department,
            string status,
            string search
        );
        Task<EmployeeDto?> GetById(int id);
        Task<List<DepartmentCountViewModel>> GetDepartmentCounts();
        Task<List<string>> GetAllDepartments();
        
        Task CreateEmployee(CreateEmployeeDto dto);
        Task<bool> UpdateEmployee(UpdateEmployeeDto dto);
        Task<bool> DeleteEmployee(int id);
    }
}