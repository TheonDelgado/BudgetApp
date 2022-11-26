using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> AllTransactions { get; }
        IEnumerable<Transaction> GetTransactionsByName(string name);
    }
}