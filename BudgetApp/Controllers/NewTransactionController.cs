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
    public class NewTransactionController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly AppDbContext context;

        public NewTransactionController(ICategoryRepository categoryRepository, AppDbContext context)
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
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CategoryId = addTransactionViewModel.SelectedCategory,
                Date = DateTime.Now,
                Name = addTransactionViewModel.Name,
                Amount = addTransactionViewModel.Amount
            };

            context.Transactions.Add(transaction);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}