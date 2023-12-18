using Abp.Web.Mvc.Views;

namespace ExpenseTracker.Web.Views
{
    public abstract class ExpenseTrackerWebViewPageBase : ExpenseTrackerWebViewPageBase<dynamic>
    {

    }

    public abstract class ExpenseTrackerWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ExpenseTrackerWebViewPageBase()
        {
            LocalizationSourceName = ExpenseTrackerConsts.LocalizationSourceName;
        }
    }
}