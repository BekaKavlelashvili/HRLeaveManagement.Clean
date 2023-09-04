using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveAllocations.Commands
{
    public class UpdateLeaveAllocationCommandHandlerTests
    {
        private readonly Mock<ILeaveAllocationRepository> _mockLeaveAllocationRepo;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private IMapper _mapper;

        public UpdateLeaveAllocationCommandHandlerTests()
        {
            _mockLeaveAllocationRepo = MockLeaveAllocationRepository.GetMockLeaveAllocationRepository();
            _mockLeaveTypeRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveAllocationProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateLeaveAllocationTest()
        {
            var command = new UpdateLeaveAllocationCommand { LeaveTypeId = 1, NumberOfDays = 10, Id = 1, Period = 2024 };

            var leaveTypeName = _mockLeaveTypeRepo.Object.GetByIdAsync(command.LeaveTypeId).Result.Name;

            _mockLeaveTypeRepo.Setup(
                x => x.IsLeaveTypeUnique(
                    It.Is<string>(name => name == leaveTypeName))).ReturnsAsync(true);

            var handler = new UpdateLeaveAllocationCommandHandler(_mockLeaveAllocationRepo.Object, _mockLeaveTypeRepo.Object, _mapper);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
