using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Fifth.Services;
using Fifth.Domain;
using Newtonsoft.Json.Linq;

namespace Fifth.Controllers
{
    [Produces("application/json")]
    [Route("api/Wallet")]
    public class WalletController : Controller
    {
        private WalletService walletService;

        public WalletController()
        {
            this.walletService = new WalletService();
        }

        // GET: api/Wallet
        [HttpGet]
        public List<Wallet> Get()
        {
            return walletService.ReadTable();
        }

        // GET: api/wallet/cutomerwallets/5
        [HttpGet("[action]/{CustomerID}")]
        public List<Wallet> CustomerWallets(int CustomerID)
        {
            return walletService.ReadAllCustomersWallets(CustomerID);
        }

        //GET: api/wallet/5
        [HttpGet("{id}", Name = "Get")]
        public Wallet Get(int id)
        {
            return walletService.ReadWallet(id);
        }
        
        // POST: api/Wallet
        [HttpPost]
        public void Post([FromBody]JToken jsonData)
        {
            walletService.Create(new Wallet(jsonData));
        }
        
        // PATCH: api/Wallet/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]JObject jsonData)
        {
            walletService.Update(id, jsonData);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{CustomerID}")]
        public void Delete(int CustomerID)
        {
            walletService.Delete(CustomerID);
        }
    }
}
