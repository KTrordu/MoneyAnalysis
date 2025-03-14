﻿using App.BLL.DTOs;
using App.BLL.IContexts;
using App.BLL.IServices;
using App.DAL.IRepositories;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IUserContext _userContext;

        public ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository, IUserContext userContext)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _userContext = userContext;
        }

        public async Task AddExpenseCategoryAsync(ExpenseCategoryDTO expenseCategoryDTO)
        {
            if (string.IsNullOrWhiteSpace(expenseCategoryDTO.ExpenseCategoryName))
            {
                throw new ArgumentException("Expense category name cannot be empty");
            }
            if (expenseCategoryDTO.ExpenseCategoryName.Length > 20)
            {
                throw new ArgumentException("Expense category name cannot be longer than 20 characters");
            }
            if (expenseCategoryDTO.ExpenseCategoryName.Length < 3)
            {
                throw new ArgumentException("Expense category name cannot be shorter than 3 characters");
            }

            var expenseCategory = new ExpenseCategory
            {
                ExpenseCategoryName = expenseCategoryDTO.ExpenseCategoryName,
                Id = expenseCategoryDTO.Id,
                UserId = expenseCategoryDTO.UserId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _expenseCategoryRepository.AddAsync(expenseCategory);
            await _expenseCategoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseCategoryDTO>> GetAllExpenseCategoriesAsync()
        {
            var expenseCategories = await _expenseCategoryRepository.GetAllAsync();

            return expenseCategories.Select(e => new ExpenseCategoryDTO
            {
                ExpenseCategoryName = e.ExpenseCategoryName,
                Id = e.Id,
                UserId = e.UserId,
                CreatedDate = e.CreatedDate
            });
        }

        public async Task<ExpenseCategoryDTO> GetExpenseCategoryByIdAsync(int id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetByIdAsync(id);

            return new ExpenseCategoryDTO
            {
                ExpenseCategoryName = expenseCategory.ExpenseCategoryName,
                Id = expenseCategory.Id,
                UserId = expenseCategory.UserId,
                CreatedDate = expenseCategory.CreatedDate
            };
        }

        public async Task UpdateExpenseCategoryAsync(ExpenseCategoryDTO expenseCategoryDTO)
        {
            if (string.IsNullOrWhiteSpace(expenseCategoryDTO.ExpenseCategoryName))
            {
                throw new ArgumentException("Expense category name cannot be empty");
            }
            if (expenseCategoryDTO.ExpenseCategoryName.Length > 20)
            {
                throw new ArgumentException("Expense category name cannot be longer than 20 characters");
            }
            if (expenseCategoryDTO.ExpenseCategoryName.Length < 3)
            {
                throw new ArgumentException("Expense category name cannot be shorter than 3 characters");
            }

            var expenseCategory = new ExpenseCategory
            {
                ExpenseCategoryName = expenseCategoryDTO.ExpenseCategoryName,
                Id = expenseCategoryDTO.Id,
                UserId = expenseCategoryDTO.UserId,
                ModifiedDate = DateTime.Now
            };

            await _expenseCategoryRepository.UpdateAsync(expenseCategory, expenseCategory.Id);
            await _expenseCategoryRepository.SaveChangesAsync();
        }

        public async Task DeleteExpenseCategoryAsync(int id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetByIdAsync(id);

            await _expenseCategoryRepository.Delete(expenseCategory);
            await _expenseCategoryRepository.SaveChangesAsync();
        }
    }
}
