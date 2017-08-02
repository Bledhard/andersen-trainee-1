using System.Collections.Generic;
using AndersenTrainee1.Services;
using AndersenTrainee1.Domain;
using System.Web.Http;

namespace AndersenTrainee1.Controllers
{
    [Route("api/wallet")]
    public class WalletController : ApiController
    {
        private WalletService walletService;

        public WalletController()
        {
            this.walletService = new WalletService();
        }

        // GET: api/wallet
        [HttpGet]
        public List<Wallet> Get()
        {
            return walletService.Get();
        }

        // GET: api/wallet/cutomerwallets/5
        [Route("api/wallet/customer/")]
        [HttpGet]
        public List<Wallet> CustomerWallets(int CustomerID)
        {
            return walletService.GetByCustomerId(CustomerID);
        }

        //GET: api/wallet/5
        [HttpGet]
        public Wallet Get(int id)
        {
            return walletService.Get(id);
        }

        // POST: api/wallet
        [HttpPost]
        public void Post(Wallet wallet)
        {
            walletService.Create(wallet);
        }

        // PATCH: api/wallet/5
        [HttpPatch]
        public void Patch(Wallet wallet)
        {
            walletService.Update(wallet);
        }

        // DELETE: api/wallet/5
        [HttpDelete]
        public void Delete(int CustomerID)
        {
            walletService.Delete(CustomerID);
        }
    }
}