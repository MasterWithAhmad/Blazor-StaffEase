using Microsoft.EntityFrameworkCore;
using StaffEase.Data;
using StaffEase.Interfaces;
using StaffEase.Models;

namespace StaffEase.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        //{
        //    return await _context.Employees.Include(e => e.Department).ToListAsync();
        //}

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        //public async Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm)
        //{
        //    return await _context.Employees
        //        .Where(e => e.Name.Contains(searchTerm) || e.Email.Contains(searchTerm) || e.Department.Name.Contains(searchTerm))
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm)
        {
            return await _context.Employees
                .Where(e => e.Name.Contains(searchTerm) ||
                            e.Email.Contains(searchTerm) ||
                            e.Department.Name.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
