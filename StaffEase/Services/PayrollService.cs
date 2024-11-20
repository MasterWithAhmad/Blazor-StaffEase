using Microsoft.EntityFrameworkCore;
using StaffEase.Data;
using StaffEase.Interfaces;
using StaffEase.Models;

namespace StaffEase.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly ApplicationDbContext _context;

        public PayrollService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync()
        {
            return await _context.Payrolls.Include(p => p.Employee).ToListAsync();
        }

        public async Task<Payroll?> GetPayrollByIdAsync(int id)
        {
            return await _context.Payrolls.Include(p => p.Employee).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> CreatePayrollAsync(Payroll payroll)
        {
            _context.Payrolls.Add(payroll);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdatePayrollAsync(Payroll payroll)
        {
            _context.Payrolls.Update(payroll);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeletePayrollAsync(int id)
        {
            var payroll = await _context.Payrolls.FindAsync(id);
            if (payroll == null) return false;

            _context.Payrolls.Remove(payroll);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Payroll>> SearchPayrollsAsync(string searchTerm)
        {
            return await _context.Payrolls
                .Where(p => p.Employee.Name.Contains(searchTerm) || p.PaymentDate.ToString().Contains(searchTerm))
                .ToListAsync();
        }
    }
}
