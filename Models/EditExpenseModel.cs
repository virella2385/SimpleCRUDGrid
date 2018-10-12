using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class EditExpenseModel
    {
    	public int customerId { get; set; }
    	public int projectId { get; set; }
    	public int expenseId { get; set; }
    	public string expenseName { get; set; }
    	public decimal expenseAmount { get; set; }
    	public string expenseDescription { get; set; }
    	[DataType(DataType.Date)]
        [DisplayAttribute(Name = "Expense Date")]
    	public DateTime expenseDate { get; set; }
    	/*public List<SelectListItem> customers { get; set; }
    	public List<SelectListItem> projects { get; set; }*/

    }
}