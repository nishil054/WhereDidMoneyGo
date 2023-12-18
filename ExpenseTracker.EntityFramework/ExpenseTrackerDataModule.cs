using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using ExpenseTracker.EntityFramework;

namespace ExpenseTracker
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(ExpenseTrackerCoreModule))]
    public class ExpenseTrackerDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExpenseTrackerDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
