using App.BLL.DTOs;
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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserContext _userContext;

        public ExpenseService(IExpenseRepository expenseRepository, IUserContext userContext)
        {
            _expenseRepository = expenseRepository;
            _userContext = userContext;
        }

        public async Task AddExpenseAsync(ExpenseDTO expenseDTO)
        {
            if (expenseDTO.UserId != _userContext.UserId)
            {
                throw new UnauthorizedAccessException();
            }
            if (expenseDTO.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (string.IsNullOrWhiteSpace(expenseDTO.ExpenseName))
            {
                throw new ArgumentException("Expense name cannot be empty");
            }
            if (expenseDTO.ExpenseName.Length > 20)
            {
                throw new ArgumentException("Expense name cannot be longer than 20 characters");
            }
            if (expenseDTO.ExpenseName.Length < 3)
            {
                throw new ArgumentException("Expense name cannot be shorter than 3 characters");
            }
            if (expenseDTO.ExpenseDate < DateTime.Now.AddYears(-1))
            {
                throw new ArgumentException("Expense date cannot be older than 1 year");
            }
            if (expenseDTO.ExpenseDate > DateTime.Now)
            {
                throw new ArgumentException("Expense date cannot be in the future");
            }

            var expense = new Expense
            {
                ExpenseName = expenseDTO.ExpenseName,
                Amount = expenseDTO.Amount,
                ExpenseDate = expenseDTO.ExpenseDate,
                ExpenseCategoryId = expenseDTO.ExpenseCategoryId,
                UserId = _userContext.UserId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            await _expenseRepository.AddAsync(expense);
            await _expenseRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync()
        {
            var expenses = await _expenseRepository.GetAllAsync();

            return expenses
                .Where(e => e.UserId == _userContext.UserId
                &&     !e.IsDeleted)
                .Select(e => new ExpenseDTO
            {
                Id = e.Id,
                ExpenseName = e.ExpenseName,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                ExpenseCategoryId = (int)e.ExpenseCategoryId!,
                UserId = e.UserId
            })
            .ToList();
        }

        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);

            return new ExpenseDTO
            {
                Id = expense.Id,
                ExpenseName = expense.ExpenseName,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                ExpenseCategoryId = (int)expense.ExpenseCategoryId!,
                UserId = expense.UserId
            };
        }

        public async Task UpdateExpenseAsync(ExpenseDTO expenseDTO)
        {
            if (expenseDTO.UserId != _userContext.UserId)
            {
                throw new UnauthorizedAccessException();
            }
            if (expenseDTO.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0");
            }
            if (string.IsNullOrWhiteSpace(expenseDTO.ExpenseName))
            {
                throw new ArgumentException("Expense name cannot be empty");
            }
            if (expenseDTO.ExpenseName.Length > 20)
            {
                throw new ArgumentException("Expense name cannot be longer than 20 characters");
            }
            if (expenseDTO.ExpenseName.Length < 3)
            {
                throw new ArgumentException("Expense name cannot be shorter than 3 characters");
            }
            if (expenseDTO.ExpenseDate < DateTime.Now.AddYears(-1))
            {
                throw new ArgumentException("Expense date cannot be older than 1 year");
            }
            if (expenseDTO.ExpenseDate > DateTime.Now)
            {
                throw new ArgumentException("Expense date cannot be in the future");
            }

            var expense = new Expense
            {
                Id = expenseDTO.Id,
                ExpenseName = expenseDTO.ExpenseName,
                Amount = expenseDTO.Amount,
                ExpenseDate = expenseDTO.ExpenseDate,
                ExpenseCategoryId = expenseDTO.ExpenseCategoryId,
                UserId = expenseDTO.UserId
            };

            await _expenseRepository.UpdateAsync(expense, expense.Id);
            await _expenseRepository.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);

            await _expenseRepository.Delete(expense);
            await _expenseRepository.SaveChangesAsync();
        }
    }
}
