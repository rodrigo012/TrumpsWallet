using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Entities { 
    public class Transaction : BaseEntity
{
        [Column("amount", TypeName = "decimal(9,2)")]
        public decimal Amount { get; set; }

        [Column("concept")]
        public string Concept { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public int userId { get; set; }

        public virtual User User { get; set; }

        [Column("account_id")]
        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public virtual Account Account { get; set; }

        [Column("to_account_id")]
        [ForeignKey("ToAccount")]
        public int toAccountID { get; set; }

        public virtual Account ToAccount { get; set; }
    }
}
