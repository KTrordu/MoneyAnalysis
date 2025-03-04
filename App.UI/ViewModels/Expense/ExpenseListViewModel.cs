namespace App.UI.ViewModels.Expense
{
    public class ExpenseListViewModel
    {
        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }
        public List<ExpenseViewModel> Expenses { get; set; }
    }
}
