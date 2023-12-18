using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.ExpenseDetails
{
    [Table("Expense_Details")]
    public class Details: FullAuditedEntity
    {
        public virtual string ExpenseName { get; set; }
        public virtual int Price { get; set; }
        public virtual DateTime Date { get; set;}
    }
}
