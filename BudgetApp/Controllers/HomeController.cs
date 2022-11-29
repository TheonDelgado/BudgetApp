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
                Transactions = transactionRepository.AllTransactions.ToList(),
                Categories = categoryRepository.AllCategories.ToList()
            };

            return View(indexView);
        }

        [HttpPost]
        public IActionResult Index(string transactionName)
        {
            var indexView = new IndexViewModel()
            {
                SearchedTransactions = transactionRepository.FilterTransactions(transactionName),
                Categories = categoryRepository.AllCategories.ToList()
            };

            return View(indexView);
        }

       
    }
}