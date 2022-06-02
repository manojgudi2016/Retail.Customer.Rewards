using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Customer.Rewards.Data.Entities;
using Retail.Customer.Rewards.Services.Interface;

namespace Retail.Customer.Rewards.Api.Controllers
{
    public class TransactionsController : Controller
    {

        private readonly ITransactionService transactionService;
        public TransactionsController(ITransactionService _transactionService)
        {
            transactionService = _transactionService;
        }
        // GET: TransactionsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransactionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionsController/Create
        //Ideally the Data entity should not be used in the presentation layer.
        //Instead a DTO should be used and the DTO should have a mapping using Automapper.

        //Use postman and create transactions, ensure the customers and products are used from the existing table.
        public ActionResult Create(Transaction transaction)
        {
            transactionService.CreateTransaction(transaction);
            return View();
        }

        // POST: TransactionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
