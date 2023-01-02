using System.ComponentModel.DataAnnotations;

namespace TrumpsWallet.Core.Models
{
    public class AccountDto
    {
        [Required(ErrorMessage = "Por favor indica fecha de creación")]
        public DateTime creationDate { get; set; }

        [Required(ErrorMessage = "Por favor indica la cantidad de dinero")]
        public float money { get; set; }

        [Required(ErrorMessage = "Por favor indica el estado de la cuenta")]
        public bool isBlocked { get; set; }

        [Required]
        public int userId { get; set; }

    }
}
