using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class Company
    {
    	[Display(Name = "Company Id")]
        public int CompanyId { get; set; }

        [Required, MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public List<Project> Projects { get; set; }
    }
}