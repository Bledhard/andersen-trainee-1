using System;

namespace AndersenTrainee1.Domain.ADONet
{
    public class Transaction : BaseEntity
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public override string TableName()
        {
            return "Transactions";
        }

        public override string SqlValuesString()
        {
            return $"\'{this.From}\', \'{this.To}\', \'{DateTime.Now}\', \'{this.Currency}\', \'{this.Amount}\'";
        }

        public override string SqlKeysString()
        {
            return "[From], [To], Date, Currency, Amount";
        }

        public override string SqlUpdateString()
        {
            throw new NotImplementedException();
        }
    }
}