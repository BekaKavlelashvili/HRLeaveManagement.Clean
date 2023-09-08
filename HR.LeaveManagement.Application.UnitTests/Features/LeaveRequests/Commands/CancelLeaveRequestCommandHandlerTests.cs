using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Commands
{
    public class CancelLeaveRequestCommandHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockLeaveRequestRepo;

        public CancelLeaveRequestCommandHandlerTests()
        {
            _mockLeaveRequestRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();
        }

        [Fact]
        public async Task CancelLeaveRequestTest()
        {
            var emailSenderMock = new Mock<Contracts.Email.IEmailSender>();

            var command = new CancelLeaveRequestCommand { Id = 1 };

            var handler = new CancelLeaveRequestCommandHandler(_mockLeaveRequestRepo.Object, emailSenderMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
