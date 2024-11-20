using StaffEase.Models;

namespace StaffEase.Interfaces
{
    public interface IPayrollService
    {
        // CRUD Operations
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync();
        Task<Payroll?> GetPayrollByIdAsync(int id);
        Task<bool> CreatePayrollAsync(Payroll payroll);
        Task<bool> UpdatePayrollAsync(Payroll payroll);
        Task<bool> DeletePayrollAsync(int id);

        // Search Functionality
        Task<IEnumerable<Payroll>> SearchPayrollsAsync(string searchTerm);
    }
}
