using App.BLL.DTOs;
using App.BLL.IServices;
using App.UI.ViewModels.ExpenseCategory;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }

        //READ: List all expense categories
        public Task<IActionResult> Index()
        {
            var expenseCategories = _expenseCategoryService.GetAllExpenseCategoriesAsync().Result;
            var model = expenseCategories.Select(expenseCategory => new ExpenseCategoryViewModel
            {
                Id = expenseCategory.Id,
                ExpenseCategoryName = expenseCategory.ExpenseCategoryName,
                CreatedDate = expenseCategory.CreatedDate
            });

            return Task.FromResult((IActionResult)View(model));
        }

        //CREATE: GET
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult((IActionResult)View());
        }

        //CREATE: POST
        [HttpPost]
        public async Task<IActionResult> Create(ExpenseCategoryViewModel expenseCategoryViewModel)
        {
            var expenseCategoryDTO = new ExpenseCategoryDTO
            {
                ExpenseCategoryName = expenseCategoryViewModel.ExpenseCategoryName
            };
            await _expenseCategoryService.AddExpenseCategoryAsync(expenseCategoryDTO);
            return await Task.FromResult((IActionResult)RedirectToAction("Index"));
        }
    }
}
