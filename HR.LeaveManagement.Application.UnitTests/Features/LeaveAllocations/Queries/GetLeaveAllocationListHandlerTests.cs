using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveAllocations.Queries
{
    public class GetLeaveAllocationListHandlerTests
    {
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveAllocationListHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetMockLeaveAllocationRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveAllocationProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveAllocationListTest()
        {
            var handler = new GetLeaveAllocationListHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveAllocationListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveAllocationDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
