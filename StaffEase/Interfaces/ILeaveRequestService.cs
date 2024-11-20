using StaffEase.Models;

namespace StaffEase.Interfaces
{
    public interface ILeaveRequestService
    {
        // CRUD Operations
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task<bool> CreateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<bool> UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<bool> DeleteLeaveRequestAsync(int id);

        // Search Functionality
        Task<IEnumerable<LeaveRequest>> SearchLeaveRequestsAsync(string searchTerm);
    }
}
