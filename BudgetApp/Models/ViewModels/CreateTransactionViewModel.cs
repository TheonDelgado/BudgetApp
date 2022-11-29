using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Models.Repositories;

namespace BudgetApp.Models.ViewModels
{
    public class CreateTransactionViewModel
    {
        public List<Category> Categories { get; set; }
        public Transaction Transaction { get; set; } = new Transaction();
    }
}