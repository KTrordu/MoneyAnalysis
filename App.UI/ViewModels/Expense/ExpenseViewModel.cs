namespace App.UI.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string UserId { get; set; }
    }
}
