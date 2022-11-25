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
        private readonly AppDbContext context;

        public HomeController(ITransactionRepository transactionRepository , AppDbContext context)
        {
            this.transactionRepository = transactionRepository;
            this.context = context;
        }

        public IActionResult Index() 
        {
            var indexView = new IndexModel()
            {
                Transactions = transactionRepository.AllTransactions.ToList<Transaction>()
            };

            return View(indexView);
        }
    }
}