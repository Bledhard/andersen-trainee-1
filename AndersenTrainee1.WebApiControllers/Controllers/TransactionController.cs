using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using AndersenTrainee1.Services.EntityFramework;
using AndersenTrainee1.Domain.EntityFramework;

namespace AndersenTrainee1.WebApiControllers
{
    [RoutePrefix("api/transaction")]
    public class TransactionController : ApiController
    {
        private EntityFrameworkTransactionService transactionService;

        public TransactionController()
        {
            this.transactionService = new EntityFrameworkTransactionService();
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
        [Route("customer/{id}")]
        [HttpGet]
        public List<Transaction> GetByCustomer(int id)
        {
            return transactionService.GetByCustomerId(id);
        }

        //GET: api/transaction/wallet/5
        [Route("wallet/{id}")]
        [HttpGet]
        public List<TaLog> GetByWallet(int id)
        {
            return transactionService.GetLogByWalletId(id);
        }

        //POST: api/transaction
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            transactionService.Create(transaction);
        }

        [Route("gen")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            transactionService.Generate();
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}