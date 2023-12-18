using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExpenseTracker.ExpenseDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.ExpenseDetails
{
    public interface IDetailsApplicationService: IApplicationService
    {
        List<CreateExpenseDto> GetDetailsData();
        Task CreateExpense(CreateExpenseDto input);
        Task UpdateTest(CreateExpenseDto input);
        Task DeleteExpense(EntityDto input);
    }
}
