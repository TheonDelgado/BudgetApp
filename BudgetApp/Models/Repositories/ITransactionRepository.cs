using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models.Repositories
{
    public interface ITransactionRepository
    {
        List<Transaction> AllTransactions { get; }
        Transaction GetTransactionsById(Guid id);
        void SaveTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(Guid transactionId);
        List<Transaction> FilterTransactions(string name);
    }
}