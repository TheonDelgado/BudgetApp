using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Data;
using BudgetApp.Models.Repositories;
using BudgetApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;

namespace BudgetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly AppDbContext context;

        public HomeController(ITransactionRepository transactionRepository , ICategoryRepository categoryRepository, AppDbContext context)
        {
            this.transactionRepository = transactionRepository;
            this.context = context;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var indexView = new IndexViewModel()
            {
                Transactions = transactionRepository.AllTransactions.ToList<Transaction>(),
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(indexView);
        }

        [HttpPost]
        public IActionResult Index(string searchedName)
        {
            var indexView = new IndexViewModel()
            {
                SearchedTransactions = transactionRepository.GetTransactionsByName(searchedName).ToList<Transaction>(),
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(indexView);
        }

        [HttpPost]
        public IActionResult EditTransaction(string transactionName)
        {
            var indexViewModel = new IndexViewModel()
            {
                Categories = categoryRepository.AllCategories.ToList<Category>()
            };

            return View(indexViewModel);
        }
    }
}