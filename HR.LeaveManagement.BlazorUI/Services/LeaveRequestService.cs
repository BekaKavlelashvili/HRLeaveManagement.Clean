using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        private readonly IMapper _mapper;

        public LeaveRequestService(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequest)
        {
            try
            {
                await AddBearerToken();
                var response = new Response<Guid>();
                CreateLeaveRequestCommand command = _mapper.Map<CreateLeaveRequestCommand>(leaveRequest);

                await _client.LeaveRequestPOSTAsync(command);
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _client.LeaveRequestAllAsync(isLoggedInUser: false);

            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(x => x.Approved == true),
                PendingRequests = leaveRequests.Count(x => x.Approved == null),
                RejectedRequests = leaveRequests.Count(x => x.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            return model;
        }

        public async Task<LeaveRequestVM> GetLeaveRequest(int id)
        {
            var leaveRequest = await _client.LeaveRequestGETAsync(id);
            return _mapper.Map<LeaveRequestVM>(leaveRequest);
        }

        public async Task ApproveLeaveRequest(int id, bool approvalStatus)
        {
            try
            {
                var request = new ChangeLeaveRequestApprovalCommand { Approved = approvalStatus, Id = id };
                await _client.UpdateApprovalAsync(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
