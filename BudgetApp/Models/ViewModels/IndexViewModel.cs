using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Transaction> SearchedTransactions { get; set; }
    }
}