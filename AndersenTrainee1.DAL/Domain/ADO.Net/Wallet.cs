namespace AndersenTrainee1.Domain.ADONet
{
    public class Wallet : BaseEntity
    {
        public int CustomerId { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public override string TableName()
        {
            return "Wallets";
        }

        public override string SqlValuesString()
        {
            return $"\'{this.CustomerId}\', \'{this.Status}\', \'{this.Currency}\', \'{this.Amount}\'";
        }

        public override string SqlKeysString()
        {
            return "CustomerID, Status, Currency, Amount";
        }

        public override string SqlUpdateString()
        {
            return $"UPDATE {this.TableName()} " +
                   $"SET Status=\'{this.Status}\', Currency=\'{this.Currency}\', Amount=\'{this.Amount}\' " +
                   $"WHERE Id={this.Id};";
        }
    }
}