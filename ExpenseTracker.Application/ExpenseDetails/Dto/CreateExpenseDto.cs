using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.ExpenseDetails.Dto
{
    [AutoMapTo(typeof(Details))]
    public class CreateExpenseDto: EntityDto
    {
        public virtual string ExpenseName { get; set; }
        public virtual int Price { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
