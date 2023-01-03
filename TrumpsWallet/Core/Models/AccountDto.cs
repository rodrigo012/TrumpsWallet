using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Core.Models
{
    public class AccountDTO
    {
        public DateTime creationDate { get; set; }

        [Required(ErrorMessage = "Por favor indica la cantidad de dinero")]
        [Column(TypeName = "decimal(12,2)")]
        public float money { get; set; }

        [Required(ErrorMessage = "Por favor indica el estado de la cuenta")]
        public bool isBlocked { get; set; }

        [Required]
        public int userId { get; set; }

    }
}
