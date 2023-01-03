using System.ComponentModel.DataAnnotations;

namespace TrumpsWallet.Core.DTOs
{
    public class RoleDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo Nombre excede de su longitud.")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo Descripción excede de su longitud.")]
        public string Description { get; set; }
    }
}
