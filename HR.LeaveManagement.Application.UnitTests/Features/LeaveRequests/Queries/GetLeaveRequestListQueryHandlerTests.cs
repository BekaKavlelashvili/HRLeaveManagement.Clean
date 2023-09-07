using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Queries
{
    public class GetLeaveRequestListQueryHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveRequestListQueryHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveRequestListTest()
        {
            var handler = new GetLeaveRequestListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveRequestListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveRequestListDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
