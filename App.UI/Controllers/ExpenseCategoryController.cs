using App.BLL.DTOs;
using App.BLL.IServices;
using App.Domain.Entities;
using App.UI.CRUDModels.ExpenseCategory;
using App.UI.ViewModels.ExpenseCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.UI.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly IExpenseCategoryService _expenseCategoryService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService, UserManager<ApplicationUser> userManager)
        {
            _expenseCategoryService = expenseCategoryService;
            _userManager = userManager;
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
            var users = await _userManager.Users.ToListAsync();

            var model = new ExpenseCategoryCRUDModel
            {
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.UserName
                })
            };

            return await Task.FromResult((IActionResult)View(model));
        }

        //CREATE: POST
        [HttpPost]
        public async Task<IActionResult> Create(ExpenseCategoryCRUDModel expenseCategoryCRUDModel)
        {
            var expenseCategoryDTO = new ExpenseCategoryDTO
            {
                ExpenseCategoryName = expenseCategoryCRUDModel.ExpenseCategoryName
            };
            await _expenseCategoryService.AddExpenseCategoryAsync(expenseCategoryDTO);
            return await Task.FromResult((IActionResult)RedirectToAction("Index"));
        }

        //UPDATE: GET
        public async Task<IActionResult> Update(int id)
        {
            var expenseCategoryToUpdate = await _expenseCategoryService.GetExpenseCategoryByIdAsync(id);
            var users = await _userManager.Users.ToListAsync();

            return await Task.FromResult((IActionResult)
                View(new ExpenseCategoryCRUDModel
                {
                    Id = expenseCategoryToUpdate.Id,
                    ExpenseCategoryName = expenseCategoryToUpdate.ExpenseCategoryName,
                    Users = users.Select(u => new SelectListItem
                    {
                        Value = u.Id,
                        Text = u.UserName
                    })
                }
                )
            );
        }

        //UPDATE: POST
        [HttpPost]
        public async Task<IActionResult> Update(ExpenseCategoryCRUDModel expenseCategoryCRUDModel)
        {
            var expenseCategoryDTO = new ExpenseCategoryDTO
            {
                Id = expenseCategoryCRUDModel.Id,
                ExpenseCategoryName = expenseCategoryCRUDModel.ExpenseCategoryName
            };
            await _expenseCategoryService.UpdateExpenseCategoryAsync(expenseCategoryDTO);
            return await Task.FromResult((IActionResult)RedirectToAction("Index"));
        }

        //DELETE: GET
        public async Task<IActionResult> Delete(int id)
        {
            var expenseCategoryToDelete = await _expenseCategoryService.GetExpenseCategoryByIdAsync(id);
            return await Task.FromResult((IActionResult)
                View(new ExpenseCategoryCRUDModel
                {
                    Id = expenseCategoryToDelete.Id,
                    ExpenseCategoryName = expenseCategoryToDelete.ExpenseCategoryName
                }));
        }

        //DELETE: POST
        [HttpPost]
        public async Task<IActionResult> Delete(ExpenseCategoryCRUDModel expenseCategoryCRUDModel)
        {
            await _expenseCategoryService.DeleteExpenseCategoryAsync(expenseCategoryCRUDModel.Id);
            return await Task.FromResult((IActionResult)RedirectToAction("Index"));
        }
    }
}
