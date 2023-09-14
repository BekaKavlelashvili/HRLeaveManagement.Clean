using AutoMapper;
using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();

            CreateMap<LeaveRequestDetailsDto, LeaveRequestVM>()
                .ForMember(x => x.DateRequested, opt => opt.MapFrom(q => q.DateRequested.DateTime))
                .ForMember(x => x.StartDate, opt => opt.MapFrom(q => q.StartDate.DateTime))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(q => q.EndDate.DateTime))
                .ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestVM>()
                .ForMember(x => x.DateRequested, opt => opt.MapFrom(q => q.DateRequested.DateTime))
                .ForMember(x => x.StartDate, opt => opt.MapFrom(q => q.StartDate.DateTime))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(q => q.EndDate.DateTime))
                .ReverseMap();
            CreateMap<CreateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();


            //CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
            //CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
            //CreateMap<CreateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
            //CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();

            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}
