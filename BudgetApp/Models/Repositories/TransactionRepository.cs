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

        public IEnumerable<Transaction> AllTransactions => context.Transactions;
        public IEnumerable<Transaction> GetTransactionsByName(string searchedName)
        {
            return from t in context.Transactions where string.IsNullOrEmpty(searchedName) || t.Name.StartsWith(searchedName) orderby t.Name select t;
        } 
    }
}