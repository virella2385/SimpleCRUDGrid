using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [RequiredAttribute]
        public Customer Customer { get; set; }
        [RequiredAttribute]
        public List<Expense> Expenses { get; set; }
    }
}