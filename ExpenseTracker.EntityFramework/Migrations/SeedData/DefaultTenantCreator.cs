using System.Linq;
using ExpenseTracker.EntityFramework;
using ExpenseTracker.MultiTenancy;

namespace ExpenseTracker.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly ExpenseTrackerDbContext _context;

        public DefaultTenantCreator(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
