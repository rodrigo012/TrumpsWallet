using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Core.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }

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
