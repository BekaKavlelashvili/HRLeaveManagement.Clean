using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
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

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public DeleteLeaveTypeCommandHandlerTests()
        {

            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<LeaveTypeProfile>();
            });
        }

        [Fact]
        public async Task DeleteLeaveTypeTest()
        {
            var handler = new DeleteLeaveTypeCommandHandler(_mockRepo.Object);

            var result = await handler.Handle(new DeleteLeaveTypeCommand { Id = 1 }, default);

            result.ShouldBeOfType<Unit>();
        }
    }
}
