using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string CurrencyName { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string CurrencySymbol { get; set; }
        
        [NotMapped]
        public string? CurrencySymbolWithName
        {
            get
            {
                return this.CurrencySymbol + " " + this.CurrencyName;
            }
        }

    }
}
