using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models.ViewModels;
using BudgetApp.Models;
using BudgetApp.Models.Repositories;

namespace BudgetApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public TransactionController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddTransaction() 
        {
            var addTransactionViewModel = new AddTransactionViewModel(categoryRepository)
            {
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(addTransactionViewModel);
        }
    }
}