using Microsoft.EntityFrameworkCore;
using StaffEase.Data;
using StaffEase.Interfaces;
using StaffEase.Models;

namespace StaffEase.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all leave requests
        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _context.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.Reason)
                .ToListAsync();
        }

        // Get a specific leave request by ID
        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            return await _context.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.Status)
                .FirstOrDefaultAsync(lr => lr.Id == id);
        }

        // Create a new leave request
        public async Task<bool> CreateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Update an existing leave request
        public async Task<bool> UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Delete a leave request by ID
        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null) return false;

            _context.LeaveRequests.Remove(leaveRequest);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Search leave requests by employee name, leave type, or date
        public async Task<IEnumerable<LeaveRequest>> SearchLeaveRequestsAsync(string searchTerm)
        {
            return await _context.LeaveRequests
                .Where(lr => lr.Employee.Name.Contains(searchTerm) ||                            
                            lr.StartDate.ToString().Contains(searchTerm) ||
                            lr.EndDate.ToString().Contains(searchTerm))
                .ToListAsync();
        }
    }
}
