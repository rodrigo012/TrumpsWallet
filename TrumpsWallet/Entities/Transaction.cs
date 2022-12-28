using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Entities { 
    public class Transaction : BaseEntity
{
    public decimal Amount { get; set; }
    public string Concept { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }

    public int to_AccountID { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }

    public Account Account { get; set; }
    [ForeignKey("User")]
    public int UserID { get; set; }

        //  public User User { get; set; }

        //public to_account_id UserID { get; set;}



    }
}
