using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrumpsWallet.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [EmailAddress]
        public string Email { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public int Point { get; set; }


        [ForeignKey("Role")]
        public int RoleId { get; set; } = 2;
        public Role Role { get; set; }
    }
}
