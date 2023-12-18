using System.Threading.Tasks;
using Abp.Application.Services;
using ExpenseTracker.Configuration.Dto;

namespace ExpenseTracker.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}