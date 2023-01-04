using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Concept { get; set; }
        public DateTime Date { get; set; }


        public string Type { get; set; }

        public int toAccountID { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public int userId { get; set; }
        public Account Account { get; set; }
    }
}