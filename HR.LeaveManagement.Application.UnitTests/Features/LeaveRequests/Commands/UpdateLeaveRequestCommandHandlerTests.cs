using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommandHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockLeaveRequestRepo;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<UpdateLeaveRequestCommandHandler>> _mockAppLogger;

        public UpdateLeaveRequestCommandHandlerTests()
        {
            _mockLeaveRequestRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();
            _mockLeaveTypeRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mockAppLogger = new Mock<IAppLogger<UpdateLeaveRequestCommandHandler>>();

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateLeaveRequestTest()
        {
            var emailSenderMock = new Mock<HR.LeaveManagement.Application.Contracts.Email.IEmailSender>();

            var command = new UpdateLeaveRequestCommand { Id = 1, Cancelled = false, LeaveTypeId = 1, StartDate = DateTime.Parse("2023-09-08"), EndDate = DateTime.Parse("2023-09-10"), RequestComments = "test comment" };

            var handler = new UpdateLeaveRequestCommandHandler(_mockLeaveRequestRepo.Object, _mockLeaveTypeRepo.Object, _mapper, emailSenderMock.Object, _mockAppLogger.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
