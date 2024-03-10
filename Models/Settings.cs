using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Settings
    {
        [Key]
        public int SettingsId { get; set; }
        public string? InvoicesPaths { get; set; }

        /// <summary>
        /// 1 for euro, 2 for us dollar.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Currency option.")]
        public int CurrencyOption { get; set; }

        public int UserId { get; set; }


    }
}
