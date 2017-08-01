using AndersenTrainee1.Services;
using AndersenTrainee1.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AndersenTrainee1.Controllers
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
            return transactionService.Get();
        }

        //GET: api/transaction/5
        [HttpGet]
        public Transaction Get(int id)
        {
            return transactionService.Get(id);
        }

        //GET: api/transaction/customer/5
        [Route("api/[controller]/customer")]
        [HttpGet]
        public List<Transaction> GetByCustomer(int id)
        {
            return transactionService.GetByCustomerId(id);
        }

        //GET: api/transaction/wallet/5
        [Route("api/[controller]/wallet")]
        [HttpGet]
        public List<Transaction> GetByWallet(int id)
        {
            return transactionService.GetByWalletId(id);
        }

        //POST: api/transaction
        [HttpPost]
        public void Post(Transaction transaction)
        {
            transactionService.Create(transaction);
        }
    }
}