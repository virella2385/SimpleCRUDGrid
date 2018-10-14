using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models.ViewModels
{
    public class EditExpenseVM
    {
        [RequiredAttribute(ErrorMessage = "Selecting a customer is required")]
        [DisplayAttribute(Name = "Select a customer")]
        public int customerId { get; set; }

        [RequiredAttribute(ErrorMessage = "Selecting a project is required")]
        [DisplayAttribute(Name = "Select a project")]
        public int projectId { get; set; }

        public int expenseId { get; set; }

        [RequiredAttribute]
        [DisplayAttribute(Name = "Name")]
        public string expenseName { get; set; }

        [RequiredAttribute]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000.00, ErrorMessage = "Amount must be between 0.01 and 1000000.00")]
        [DisplayAttribute(Name = "Amount")]
        public decimal expenseAmount { get; set; }

        [DisplayAttribute(Name = "Description")]
        public string expenseDescription { get; set; }

        [RequiredAttribute]
        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Date")]
        public DateTime expenseDate { get; set; }
        public List<SelectListItem> customers { get; set; }
        public List<SelectListItem> projects { get; set; }

    }
}