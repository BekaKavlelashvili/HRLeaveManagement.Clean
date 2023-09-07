using AutoMapper;
using Castle.Core.Smtp;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveRequests.Commands
{
    public class CreateLeaveRequestCommandHandlerTests
    {
        private readonly Mock<ILeaveRequestRepository> _mockLeaveRequestRepo;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private IMapper _mapper;

        public CreateLeaveRequestCommandHandlerTests()
        {
            _mockLeaveRequestRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();
            _mockLeaveTypeRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveRequestProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        //[Fact]
        //public async Task CreateLeaveRequestTest()
        //{
        //    var command = new CreateLeaveRequestCommand { LeaveTypeId = 1 };

        //    var handler = new CreateLeaveRequestCommandHandler(_mockLeaveRequestRepo.Object, _mockLeaveTypeRepo.Object, _mapper);

        //    var result = await handler.Handle(command, CancellationToken.None);

        //    result.ShouldBeOfType<Unit>();
        //}
    }
}
