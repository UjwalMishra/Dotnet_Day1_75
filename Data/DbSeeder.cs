using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Employees.Any())
                return;

            var employees = new List<Employee>
            {
                new Employee { Name = "Amit Sharma", Department = "Engineering", Email = "amit@company.com", IsActive = true },
                new Employee { Name = "Priya Verma", Department = "HR", Email = "priya@company.com", IsActive = true },
                new Employee { Name = "Rahul Mehta", Department = "Engineering", Email = "rahul@company.com", IsActive = false },
                new Employee { Name = "Sneha Iyer", Department = "Finance", Email = "sneha@company.com", IsActive = true },
                new Employee { Name = "Karan Singh", Department = "Marketing", Email = "karan@company.com", IsActive = false },
                new Employee { Name = "Neha Gupta", Department = "HR", Email = "neha@company.com", IsActive = true }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}