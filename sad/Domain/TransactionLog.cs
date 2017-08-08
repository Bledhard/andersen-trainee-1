using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndersenTrainee1.Domain
{
    public class TransactionLog
    {
        public string FromName { get; set; }
        public string FromSurname { get; set; }
        public string ToName { get; set; }
        public string ToSurname { get; set; }
        public string Currency { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}