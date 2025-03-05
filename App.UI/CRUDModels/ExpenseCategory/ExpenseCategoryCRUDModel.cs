using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.CRUDModels.ExpenseCategory
{
    public class ExpenseCategoryCRUDModel
    {
        public int Id { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
