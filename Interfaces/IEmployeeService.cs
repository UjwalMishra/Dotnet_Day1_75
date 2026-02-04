using EmployeeManagement.DTO;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployees(
            string department,
            string status,
            string search
        );

        EmployeeDto? GetById(int id);
        
        List<DepartmentCountViewModel> GetDepartmentCounts();
        
        List<string> GetAllDepartments();
    
    }
}