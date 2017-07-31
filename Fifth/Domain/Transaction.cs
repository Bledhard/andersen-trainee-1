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
    }
}
