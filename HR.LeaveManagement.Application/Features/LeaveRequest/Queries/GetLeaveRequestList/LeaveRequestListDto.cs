using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System.Reflection.Metadata.Ecma335;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class LeaveRequestListDto
    {
        public string RequestingEmployeeId { get; set; }

        public LeaveTypeDto LeaveType { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool? Approved { get; set; }

    }
}