using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public int Pin { get; set; }

    }
}
