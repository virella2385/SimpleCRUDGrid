using System.Collections.Generic;

namespace SimpleCRUDGridWebApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
    }
}