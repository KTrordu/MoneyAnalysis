using App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.IServices
{
    public interface IExpenseCategoryService
    {
        Task AddExpenseCategoryAsync(ExpenseCategoryDTO expenseCategoryDTO);
        Task<IEnumerable<ExpenseCategoryDTO>> GetAllExpenseCategoriesAsync();
        Task<ExpenseCategoryDTO> GetExpenseCategoryByIdAsync(int id);
        Task UpdateExpenseCategoryAsync(ExpenseCategoryDTO expenseCategoryDTO);
        Task DeleteExpenseCategoryAsync(int id);
    }
}
