using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExpenseTracker.MultiTenancy.Dto;

namespace ExpenseTracker.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
