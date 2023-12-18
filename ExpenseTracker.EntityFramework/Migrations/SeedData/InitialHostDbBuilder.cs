using ExpenseTracker.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ExpenseTracker.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ExpenseTrackerDbContext _context;

        public InitialHostDbBuilder(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
