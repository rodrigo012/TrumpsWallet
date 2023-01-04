using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrumpsWallet.Core.DTOs
{
    public class UserDTO
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
    }
}
