using System.ComponentModel.DataAnnotations;

namespace TrumpsWallet.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
