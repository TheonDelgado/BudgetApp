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
        public IActionResult NewTransaction() 
        {
            var newTransactionViewModel = new NewTransactionViewModel()
            {
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(newTransactionViewModel);
        }

        [HttpPost]
        public IActionResult NewTransaction(NewTransactionViewModel newTransactionViewModel) 
        {
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CategoryId = newTransactionViewModel.SelectedCategory,
                Date = DateTime.Now,
                Name = newTransactionViewModel.Name,
                Amount = newTransactionViewModel.Amount
            };

            context.Transactions.Add(transaction);
            context.SaveChanges();

            return Redirect("~/Home/Index");
        }
    }
}