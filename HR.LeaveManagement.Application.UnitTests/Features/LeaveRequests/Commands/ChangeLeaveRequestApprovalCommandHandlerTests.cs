using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Commands
{
    public class ChangeLeaveRequestApprovalCommandHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockLeaveRequestRepo;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private IMapper _mapper;

        public ChangeLeaveRequestApprovalCommandHandlerTests()
        {
            _mockLeaveRequestRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();
            _mockLeaveTypeRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task CancelLeaveRequestTest()
        {
            var emailSenderMock = new Mock<Contracts.Email.IEmailSender>();

            var command = new ChangeLeaveRequestApprovalCommand { Id = 1, Approved = true };

            var handler = new ChangeLeaveRequestApprovalCommandHandler(_mockLeaveRequestRepo.Object, _mockLeaveTypeRepo.Object, _mapper, emailSenderMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
