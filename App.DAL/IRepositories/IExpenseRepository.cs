using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.IRepositories
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(int id);
        Task UpdateAsync(Expense expense, int id);
        Task Delete(Expense expense);
        Task SaveChangesAsync();
    }
}
