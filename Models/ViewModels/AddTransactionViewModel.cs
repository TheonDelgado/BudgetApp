using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Models.Repositories;

namespace BudgetApp.Models.ViewModels
{
    public class AddTransactionViewModel
    {
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }

        public AddTransactionViewModel(ICategoryRepository categoryRepository)
        {
            Categories = categoryRepository.AllCategories.ToList<Category>();
        }
    }
}