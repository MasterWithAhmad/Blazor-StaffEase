using StaffEase.Models;

namespace StaffEase.Interfaces
{
    public interface IDepartmentService
    {
        // CRUD Operations
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<bool> CreateDepartmentAsync(Department department);
        Task<bool> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);

        // Search Functionality
        Task<IEnumerable<Department>> SearchDepartmentsAsync(string searchTerm);
    }
}
