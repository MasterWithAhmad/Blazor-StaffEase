using System.ComponentModel.DataAnnotations;

namespace StaffEase.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Request Status")]
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        // Navigation property
        public Employee? Employee { get; set; }

        public enum LeaveStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}