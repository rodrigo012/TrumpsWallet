namespace TrumpsWallet.Core.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Concept { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int AccountID { get; set; }
        public int toAccountID { get; set; }
    }
}
