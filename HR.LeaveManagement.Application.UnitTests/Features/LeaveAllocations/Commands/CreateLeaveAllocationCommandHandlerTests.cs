using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveAllocations.Commands
{
    public class CreateLeaveAllocationCommandHandlerTests
    {
        private readonly Mock<ILeaveAllocationRepository> _mockLeaveAllocationRepo;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private IMapper _mapper;

        public CreateLeaveAllocationCommandHandlerTests()
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
        public async Task CreateLeaveAllocationTest()
        {
            var command = new CreateLeaveAllocationCommand { LeaveTypeId = 1 };

            var handler = new CreateLeaveAllocationCommandHandler(_mockLeaveAllocationRepo.Object, _mockLeaveTypeRepo.Object, _mapper);

            var result = await handler.Handle(command, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
