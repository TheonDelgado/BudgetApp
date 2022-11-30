using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Data;

namespace BudgetApp.Models.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext context;

        public TransactionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Transaction> AllTransactions => context.Transactions.ToList();

        public void SaveTransaction(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }
        
        public void UpdateTransaction(Transaction transaction)
        {
            context.Transactions.Update(transaction);
            context.SaveChanges();
        }

        public void DeleteTransaction(Guid transactionId)
        {
            var transaction = context.Transactions.FirstOrDefault(t => t.Id == transactionId);

            context.Transactions.Remove(transaction);
            context.SaveChanges();
        }
        
        public Transaction GetTransactionsById(Guid id)
        {
            return context.Transactions.FirstOrDefault(t => t.Id == id); // .FirstOrDefault() executes the query against the database
        }

        public List<Transaction> FilterTransactions(string name)
        {
            var query = context.Transactions.Where(t => t.Name.Contains(name));

            return query.ToList(); // .ToList() executes the query against the database
        }
    }
}