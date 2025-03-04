using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.CRUDModels.Expense
{
    public class ExpenseCRUDModel
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SelectListItem> ExpenseCategories { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
