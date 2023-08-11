using HR.LeaveManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagement.Domain
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        public LeaveType? LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int PeriodId { get; set; }
    }
}