using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using ExpenseTracker.ExpenseDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExpenseTracker.ExpenseDetails
{
    public class DetailsApplicationService: ExpenseTrackerApplicationModule, IDetailsApplicationService
    {
        private readonly IRepository<Details> _expenseDetailsRepository;

        public DetailsApplicationService(IRepository<Details> expenseDetailsRepository)
        {
            _expenseDetailsRepository = expenseDetailsRepository;
        }

        public List<CreateExpenseDto> GetDetailsData()
        {
            var data = (from a in _expenseDetailsRepository.GetAll()
                        select new CreateExpenseDto
                        {
                            Id = a.Id,
                            ExpenseName = a.ExpenseName,
                            Price = a.Price,
                            Date = a.Date,
                        }).ToList();
            return data;
        }
        
        public async Task CreateExpense(CreateExpenseDto input)
        {
            //Details obj = new Details();
            //obj.ExpenseName=input.ExpenseName;
            //obj.Price=input.Price;
            //obj.Date = input.Date;
            var Details = input.MapTo<Details>();
            await _expenseDetailsRepository.InsertAsync(Details);
        }

        public async Task UpdateTest(CreateExpenseDto input)
        {
            var Tests = await _expenseDetailsRepository.GetAsync(input.Id);
            Tests.ExpenseName = input.ExpenseName;
            Tests.Price = input.Price;
            Tests.Date = input.Date;
            await _expenseDetailsRepository.UpdateAsync(Tests);
        }

        public async Task DeleteExpense(EntityDto input)
        {
            await _expenseDetailsRepository.DeleteAsync(input.Id);
        }
    }
}
