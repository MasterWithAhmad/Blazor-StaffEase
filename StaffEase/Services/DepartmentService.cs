using Microsoft.EntityFrameworkCore;
using StaffEase.Data;
using StaffEase.Interfaces;
using StaffEase.Models;

namespace StaffEase.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> CreateDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Department>> SearchDepartmentsAsync(string searchTerm)
        {
            return await _context.Departments
                .Where(d => d.Name.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
