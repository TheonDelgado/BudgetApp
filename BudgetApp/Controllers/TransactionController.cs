using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models.ViewModels;
using BudgetApp.Models;
using BudgetApp.Models.Repositories;
using BudgetApp.Data;

namespace BudgetApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly AppDbContext context;

        public TransactionController(ICategoryRepository categoryRepository, AppDbContext context)
        {   
            this.categoryRepository = categoryRepository;
            this.context = context;
        }

        [HttpGet]
        public IActionResult AddTransaction() 
        {
            var addTransactionViewModel = new AddTransactionViewModel()
            {
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(addTransactionViewModel);
        }

        [HttpPost]
        public IActionResult AddTransaction(AddTransactionViewModel addTransactionViewModel) 
        {
            Console.WriteLine(addTransactionViewModel.SelectedCategory.CategoryName);
            // var transaction = new Transaction()
            // {
            //     Id = Guid.NewGuid(),

            // }

            return Redirect("~/Home/Index");
        }
    }
}