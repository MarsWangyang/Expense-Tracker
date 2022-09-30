using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        // Save CategoryId --> foreign key (use navigation method below)
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // navigation property

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        // Can be a nullable string
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}