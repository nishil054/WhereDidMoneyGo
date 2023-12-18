using Xunit;

namespace ExpenseTracker.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
        }
    }
}
