using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class ExpenseCategory : BaseEntity
    {
        public string ExpenseCategoryName { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
