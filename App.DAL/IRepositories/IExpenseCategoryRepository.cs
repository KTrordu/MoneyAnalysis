using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.IRepositories
{
    public interface IExpenseCategoryRepository
    {
        Task AddAsync(ExpenseCategory expenseCategory);
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();
        Task<ExpenseCategory> GetByIdAsync(int id);
        Task UpdateAsync(ExpenseCategory expenseCategory, int id);
        Task Delete(ExpenseCategory expenseCategory);
        Task SaveChangesAsync();
    }
}
