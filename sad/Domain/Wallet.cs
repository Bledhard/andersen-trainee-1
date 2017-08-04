namespace AndersenTrainee1.Domain
{
    public class Wallet
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public string SqlValuesString()
        {
            return $"\'{this.CustomerId}, \'{this.Status}, \'{this.Currency}, \'{this.Amount}";
        }

        public static string SqlKeysString()
        {
            return "CustomerID, Status, Currency, Amount";
        }

        public string SqlUpdateString()
        {
            return $"UPDATE Wallets " +
                   $"SET Status=\'{this.Status}, Currency=\'{this.Currency}, Amount=\'{this.Amount} " +
                   $"WHERE Id={this.Id};";
        }
    }
}