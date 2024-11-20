using StaffEase.Models;

namespace StaffEase.Interfaces
{
    public interface IEmployeeService
    {
        // CRUD Operations
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<bool> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);

        // Search Functionality
        Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm);
    }
}