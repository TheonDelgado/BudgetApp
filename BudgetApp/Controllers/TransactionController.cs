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
        private readonly ITransactionRepository transactionRepository;

        public TransactionController(ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            this.categoryRepository = categoryRepository;
            this.transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult CreateTransaction()
        {
            var newTransactionViewModel = new CreateTransactionViewModel()
            {
                Categories = categoryRepository.AllCategories.ToList()
            };

            return View(newTransactionViewModel);
        }

        [HttpPost]
        public IActionResult CreateTransaction(CreateTransactionViewModel createTransactionViewModel)
        {
            createTransactionViewModel.Transaction.Id = Guid.NewGuid();
            createTransactionViewModel.Transaction.Date = DateTime.Now;

            transactionRepository.SaveTransaction(createTransactionViewModel.Transaction);

            return Redirect("~/Home/Index");
        }

        [HttpGet("[controller]/[action]/{transactionId}")]
        public IActionResult EditTransaction([FromRoute] Guid transactionId)
        {
            var transaction = transactionRepository.GetTransactionsById(transactionId);
            
            var viewModel = new CreateTransactionViewModel()
            {
                Categories = categoryRepository.AllCategories.ToList(),
                Transaction = transaction
            };

            return PartialView("EditTransaction", viewModel);
        }
        
        [HttpPost]
        public IActionResult EditTransaction(CreateTransactionViewModel createTransactionViewModel)
        {
            transactionRepository.UpdateTransaction(createTransactionViewModel.Transaction);

            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet("[controller]/[action]/{transactionId}")]
        public IActionResult DeleteTransaction([FromRoute] Guid transactionId)
        {
            transactionRepository.DeleteTransaction(transactionId);

            return RedirectToAction("Index", "Home");
        }
    }
}