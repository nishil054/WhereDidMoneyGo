using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ExpenseTracker.EntityFramework;

namespace ExpenseTracker.Migrator
{
    [DependsOn(typeof(ExpenseTrackerDataModule))]
    public class ExpenseTrackerMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ExpenseTrackerDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}