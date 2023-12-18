using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using ExpenseTracker.Authorization.Users;
using ExpenseTracker.MultiTenancy;
using ExpenseTracker.Users;
using Microsoft.AspNet.Identity;

namespace ExpenseTracker
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ExpenseTrackerAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected ExpenseTrackerAppServiceBase()
        {
            LocalizationSourceName = ExpenseTrackerConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}