namespace BudgetApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}