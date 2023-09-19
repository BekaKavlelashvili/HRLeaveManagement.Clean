using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Pages.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Shared;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Details
    {
        [Inject] ILeaveRequestService leaveRequestService { get; set; }

        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }

        string ClassName;
        string HeadingText;

        public LeaveRequestVM Model { get; private set; } = new LeaveRequestVM();

        protected override async void OnParametersSet()
        {
            Model = await leaveRequestService.GetLeaveRequest(Id);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Model.Approved == null)
            {
                ClassName = "warning";
                HeadingText = "Pending Approval";
            }
            else if (Model.Approved == true)
            {
                ClassName = "success";
                HeadingText = "Approved";
            }
            else
            {
                ClassName = "danger";
                HeadingText = "Rejected";
            }
        }

        async Task ChangeApproval(bool approvalStatus)
        {
            await leaveRequestService.ApproveLeaveRequest(Id, approvalStatus);
            NavigationManager.NavigateTo("leaverequests/");
        }
    }
}