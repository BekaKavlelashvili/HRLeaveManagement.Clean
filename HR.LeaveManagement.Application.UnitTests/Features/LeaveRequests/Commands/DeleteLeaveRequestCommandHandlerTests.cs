using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
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

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Commands
{
    public class DeleteLeaveRequestCommandHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockRepo;
        private IMapper _mapper;

        public DeleteLeaveRequestCommandHandlerTests()
        {
            _mockRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteLeaveRequestTest()
        {
            var handler = new DeleteLeaveRequestCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteLeaveRequestCommand { Id = 1 }, default);

            result.ShouldBeOfType<Unit>();
        }
    }
}
