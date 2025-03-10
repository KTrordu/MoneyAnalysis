using App.BLL.IServices;
using App.UI.CRUDModels.Expense;
using App.UI.ViewModels.Expense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly IUserService _userService;

        public ExpenseController(IExpenseService expenseService, IExpenseCategoryService expenseCategoryService, IUserService userService)
        {
            _expenseService = expenseService;
            _expenseCategoryService = expenseCategoryService;
            _userService = userService;
        }

        //GET: List all expenses
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

        //GET: CREATE
        public async Task<IActionResult> Create()
        {
            var expenseCategories = await _expenseCategoryService.GetAllExpenseCategoriesAsync();
            var users = await _userService.GetAllUsersAsync();

            var model = new ExpenseCRUDModel
            {
                ExpenseCategories = expenseCategories.Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.ExpenseCategoryName
                }),
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
            };
            return await Task.FromResult((IActionResult)View(model));
        }
    }
}
