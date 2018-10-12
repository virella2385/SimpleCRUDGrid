using System.ComponentModel.DataAnnotations;

namespace SimpleCRUDGridWebApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [RequiredAttribute]
        [DisplayAttribute(Name = "Customer Name")]
        public string CustomerName { get; set; }
    }
}