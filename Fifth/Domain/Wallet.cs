namespace Fifth.Domain
{
    public class Wallet
    {
        public int id { get; set; }
        public int CustomerID { get; set; }
        public bool Status { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
