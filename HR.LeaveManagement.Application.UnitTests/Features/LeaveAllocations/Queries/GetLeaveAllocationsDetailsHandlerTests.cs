using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
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
    public class GetLeaveAllocationsDetailsHandlerTests
    {
        private readonly Mock<ILeaveAllocationRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveAllocationsDetailsHandlerTests()
        {
            _mockRepo = MockLeaveAllocationRepository.GetMockLeaveAllocationRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveAllocationProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveAllocationWithDetailsTest()
        {
            var handler = new GetLeaveAllocationsDetailsHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveAllocationDetailsQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<LeaveAllocationDetailsDto>();
            result.Id.ShouldBe(1);
        }
    }
}
