using System;
using AndersenTrainee1.Extensions;

namespace AndersenTrainee1.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public string SqlValuesString()
        {
            return $"\'{this.From}, \'{this.To}, \'{this.Date.ToDbDateTime()}, \'{this.Currency}, \'{this.Amount}";
        }

        public static string SqlKeysString()
        {
            return "From, To, Date, Currency, Amount";
        }

        public string SqlUpdateString()
        {
            return $"UPDATE Transactions " +
                   $"SET From=\'{this.From}, To=\'{this.To}, Date=\'{this.Date.ToDbDateTime()}, Currency=\'{this.Currency}, Amount=\'{this.Amount} " +
                   $"WHERE Id={Id};";
        }
    }
}