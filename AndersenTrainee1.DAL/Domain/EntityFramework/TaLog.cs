using System;

namespace AndersenTrainee1.Domain.EntityFramework
{
    public class TaLog
    {
        public string fn { get; set; }
        public string fs { get; set; }
        public string tn { get; set; }
        public string ts { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }

        public TaLog(string fn, string fs, string tn, string ts, int Amount, string Currency, DateTime Date)
        {
            this.fn = fn;
            this.fs = fs;
            this.tn = tn;
            this.ts = ts;
            this.Amount = Amount;
            this.Currency = Currency;
            this.Date = Date;
        }
    }
}
