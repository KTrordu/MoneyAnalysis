using App.BLL.IServices;
using App.UI.ViewModels.Expense;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseController(IExpenseService expenseService, IExpenseCategoryService expenseCategoryService)
        {
            _expenseService = expenseService;
            _expenseCategoryService = expenseCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            var expenseCategories = await _expenseCategoryService.GetAllExpenseCategoriesAsync();

            var expenseList = new List<ExpenseViewModel>();

            foreach (var expense in expenses)
            {
                var expenseListItem = new ExpenseViewModel
                {
                    Id = expense.Id,
                    ExpenseName = expense.ExpenseName,
                    Amount = expense.Amount,
                    ExpenseDate = expense.ExpenseDate,
                    ExpenseCategoryId = expense.ExpenseCategoryId,
                    ExpenseCategoryName = expenseCategories.FirstOrDefault(e => e.Id == expense.ExpenseCategoryId).ExpenseCategoryName,
                    UserId = expense.UserId
                };

                expenseList.Add(expenseListItem);
            }

            return await Task.FromResult((IActionResult)View(expenseList));
        }
    }
}
