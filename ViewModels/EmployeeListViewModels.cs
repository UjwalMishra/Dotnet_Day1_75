using EmployeeManagement.DTO;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeDto> Employees { get; set; } = new();
        
        public int TotalEmployees { get; set; }

        public string SelectedDepartment { get; set; } = string.Empty;

        public string SelectedStatus { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;
    }
}