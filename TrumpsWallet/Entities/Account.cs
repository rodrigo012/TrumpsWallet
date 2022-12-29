using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Entities
{
    public class Account:BaseEntity
    {
        public DateTime creationDate { get; set; }
        public float money { get; set; }
        public bool isBlocked { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; } 
        public User User { get; set; }
    }
}
