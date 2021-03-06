using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [Required]
        [DisplayAttribute(Name = "Name")]
        public string ExpenseName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Date")]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        [RequiredAttribute]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}