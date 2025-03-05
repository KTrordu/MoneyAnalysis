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
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly AppDbContext _db;

        public ExpenseCategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ExpenseCategory expenseCategory)
        {
            await _db.ExpenseCategories.AddAsync(expenseCategory);
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllAsync()
        {
            return await _db.ExpenseCategories
                .Where(ec => !ec.IsDeleted)
                .ToListAsync();
        }

        public async Task<ExpenseCategory> GetByIdAsync(int id)
        {
            return await _db.ExpenseCategories
                .Where(ec => !ec.IsDeleted)
                .FirstOrDefaultAsync(ec => ec.Id == id);
        }

        public async Task UpdateAsync(ExpenseCategory expenseCategory, int id)
        {
            ExpenseCategory expenseCategoryToUpdate = await GetByIdAsync(id);

            expenseCategoryToUpdate.ExpenseCategoryName = expenseCategory.ExpenseCategoryName;
            expenseCategoryToUpdate.UserId = expenseCategory.UserId;
            expenseCategoryToUpdate.ModifiedDate = DateTime.Now;

            _db.ExpenseCategories.Update(expenseCategoryToUpdate);
        }

        public Task Delete(ExpenseCategory expenseCategory)
        {
            expenseCategory.IsDeleted = true;
            expenseCategory.DeletedDate = DateTime.Now;
            expenseCategory.ModifiedDate = DateTime.Now;

            return Task.FromResult(_db.ExpenseCategories.Update(expenseCategory));
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
