using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
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
    public class DeleteLeaveAllocationCommandHandlerTests
    {
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private IMapper _mapper;

        public DeleteLeaveAllocationCommandHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetMockLeaveAllocationRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveAllocationProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteLeaveAllocationTest()
        {
            var handler = new DeleteLeaveAllocationCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteLeaveAllocationCommand { Id = 1 }, default);

            result.ShouldBeOfType<Unit>();
        }
    }
}
