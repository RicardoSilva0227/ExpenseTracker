using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Settings
    {
        [Key]
        public int SettingsId { get; set; }
        public string? InvoicesPaths { get; set; }

    }
}
