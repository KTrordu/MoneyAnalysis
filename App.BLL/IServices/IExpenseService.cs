using App.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.IServices
{
    public interface IExpenseService
    {
        Task AddExpenseAsync(ExpenseDTO expenseDTO);
        Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync();
        Task<ExpenseDTO> GetExpenseByIdAsync(int id);
        Task UpdateExpenseAsync(ExpenseDTO expenseDTO);
        Task DeleteExpenseAsync(int id);
    }
}
