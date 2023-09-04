using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetMockLeaveAllocationRepository()
        {
            var leaveAllocations = new List<LeaveAllocation>
            {
                new LeaveAllocation
                {
                    Id = 1,
                    NumberOfDays = 10,
                    Period = 2023,
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
                new LeaveAllocation
                {
                    Id = 2,
                    NumberOfDays = 15,
                    Period = 2023,
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
                new LeaveAllocation
                {
                    Id = 3,
                    NumberOfDays = 18,
                    Period = 2023,
                    LeaveType = new LeaveType
                    {
                        Id = 1,
                        DefaultDays = 10,
                        Name = "Test Vacation",
                    },
                    LeaveTypeId = 1,
                },
            };

            var mockRepo = new Mock<ILeaveAllocationRepository>();

            mockRepo.Setup(x => x.GetLeaveAllocationsWithDetails()).ReturnsAsync(leaveAllocations);

            int id = 1;
            mockRepo.Setup(x => x.GetLeaveAllocationWithDetails(id)).ReturnsAsync(leaveAllocations.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(x => x.CreateAsync(It.IsAny<LeaveAllocation>()))
                .Returns((LeaveAllocation leaveAllocation) =>
                {
                    leaveAllocations.Add(leaveAllocation);
                    return Task.CompletedTask;
                });


            mockRepo.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(leaveAllocations.FirstOrDefault(x => x.Id == id));

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<LeaveAllocation>()))
                .Returns((LeaveAllocation leaveAllocation) =>
                {
                    leaveAllocations.Remove(leaveAllocation);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
