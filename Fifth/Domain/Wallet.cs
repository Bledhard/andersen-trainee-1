using Newtonsoft.Json.Linq;

namespace Fifth.Domain
{
    public class Wallet
    {
        public int id { get; set; }
        public int CustomerID { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public Wallet(int id, int CustomerID, bool Status, string Currency, decimal Amount)
        {
            this.id = id;
            this.CustomerID = CustomerID;
            this.Status = Status;
            this.Currency = Currency;
            this.Amount = Amount;
        }

        public Wallet()
        {

        }

        public Wallet(JToken jsonData)
        {
            this.CustomerID = (int)jsonData["customerID"];
            this.Status = (bool)jsonData["status"];
            this.Currency = (string)jsonData["currency"];
            this.Amount = (int)jsonData["amount"];
        }
    }
}
