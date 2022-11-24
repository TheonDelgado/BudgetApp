using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
    }
}