using Microsoft.AspNetCore.Mvc;
using Fifth.Services;
using System;
using Fifth.Domain;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Fifth.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private TransactionService transactionService;

        public TransactionController()
        {
            this.transactionService = new TransactionService();
        }

        //GET: api/transaction
        [HttpGet]
        public List<Transaction> Get()
        {
            return transactionService.ReadTable();
        }

        //GET: api/transaction/5
        [HttpGet("{id}")]
        public Transaction Id(int id)
        {
            return transactionService.ReadTransaction(id);
        }

        //GET: api/transaction/customer/5
        [HttpGet("[action]/{id}")]
        public List<Transaction> Customer(int id)
        {
            return transactionService.ReadCustomersTransactions(id);
        }

        //GET: api/transaction/wallet/5
        [HttpGet("[action]/{id}")]
        public List<Transaction> Wallet(int id)
        {
            return transactionService.ReadWalletsTransactions(id);
        }

        //POST: api/transaction
        [HttpPost]
        public void Post([FromBody]JToken jsonData)
        {
            transactionService.Create(new Transaction(jsonData));
        }
    }
}