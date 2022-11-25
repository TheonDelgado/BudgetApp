namespace BudgetApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}