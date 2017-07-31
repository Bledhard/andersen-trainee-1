using Newtonsoft.Json.Linq;
using System;

namespace Fifth.Domain
{
    public class Transaction
    {
        public int id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(int id, int From, int To, string Currency, decimal Amount, DateTime Date)
        {
            this.id = id;
            this.From = From;
            this.To = To;
            this.Currency = Currency;
            this.Amount = Amount;
            this.Date = Date;
        }

        public Transaction()
        {

        }

        public Transaction(JToken jsonData)
        {
            this.From = (int)jsonData["from"];
            this.To = (int)jsonData["to"];
            this.Currency = (string)jsonData["currency"];
            this.Amount = (int)jsonData["amount"];
            this.Date = new DateTime((int)jsonData["year"], (int)jsonData["month"], (int)jsonData["day"], (int)jsonData["hour"], (int)jsonData["minute"], (int)jsonData["second"], (int)jsonData["ms"]);
        }


    }
}
