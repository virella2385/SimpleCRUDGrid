using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class AddExpenseModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Required, MaxLength(100)]
        [DisplayAttribute(Name = "Expense Name")]
        public string ExpenseName { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayAttribute(Name = "Amount")]
        public decimal ExpenseAmount { get; set; }

        [DisplayAttribute(Name = "Description")]
        public string ExpenseDescription { get; set; }
    }
}