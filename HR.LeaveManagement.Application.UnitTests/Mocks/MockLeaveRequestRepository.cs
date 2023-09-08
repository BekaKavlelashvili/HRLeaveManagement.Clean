using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetMockLeaveRequestRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest
                {
                    Id = 1,
                    StartDate = DateTime.Parse("2023-09-08"),
                    EndDate = DateTime.Parse("2023-09-10"),
                    RequestComments = "Test Comment",
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
                new LeaveRequest
                {
                    Id = 2,
                    StartDate = DateTime.Parse("2023-09-08"),
                    EndDate = DateTime.Parse("2023-09-10"),
                    RequestComments = "Test Comment",
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
                new LeaveRequest
                {
                    Id = 3,
                    StartDate = DateTime.Parse("2023-09-09"),
                    EndDate = DateTime.Parse("2023-09-11"),
                    RequestComments = "Test Comment",
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
            };

            var mockRepo = new Mock<ILeaveRequestRepository>();

            mockRepo.Setup(x => x.GetLeaveRequestsWithDetails()).ReturnsAsync(leaveRequests);

            int id = 1;
            mockRepo.Setup(x => x.GetLeaveRequestWithDetails(id)).ReturnsAsync(leaveRequests.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveRequest>()))
                .Returns((LeaveRequest leaveRequest) =>
                {
                    leaveRequests.Add(leaveRequest);
                    return Task.CompletedTask;
                });


            mockRepo.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(leaveRequests.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<LeaveRequest>()))
                .Returns((LeaveRequest leaveRequest) =>
                {
                    leaveRequests.Remove(leaveRequest);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
