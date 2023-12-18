using Abp.AutoMapper;
using ExpenseTracker.Sessions.Dto;

namespace ExpenseTracker.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}