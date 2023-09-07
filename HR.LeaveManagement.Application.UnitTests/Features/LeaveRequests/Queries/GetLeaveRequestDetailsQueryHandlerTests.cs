using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Queries
{
    public class GetLeaveRequestDetailsQueryHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveRequestDetailsQueryHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveRequestDetailsTest()
        {
            var handler = new GetLeaveRequestDetailsQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveRequestDetailsQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<LeaveRequestDetailsDto>();
        }
    }
}
