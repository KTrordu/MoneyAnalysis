using App.DAL.IRepositories;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _db;

        public ExpenseRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Expense expense)
        {
            await _db.Expenses.AddAsync(expense);
        }

        public async Task<Expense> GetByIdAsync(int id)
        {
            return await _db.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _db.Expenses.ToListAsync();
        }

        public async Task UpdateAsync(Expense expense, int id)
        {
            Expense expenseToUpdate = await GetByIdAsync(id);

            expenseToUpdate.ExpenseName = expense.ExpenseName;
            expenseToUpdate.Amount = expense.Amount;
            expenseToUpdate.ExpenseDate = expense.ExpenseDate;
            expenseToUpdate.ExpenseCategoryId = expense.ExpenseCategoryId;
            expenseToUpdate.UserId = expense.UserId;
            expenseToUpdate.ModifiedDate = DateTime.Now;

            _db.Expenses.Update(expenseToUpdate);
        }

        public Task Delete(Expense expense)
        {
            expense.IsDeleted = true;
            expense.DeletedDate = DateTime.Now;
            expense.ModifiedDate = DateTime.Now;

            return Task.FromResult(_db.Expenses.Update(expense));
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
