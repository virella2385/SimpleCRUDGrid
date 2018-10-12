using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUDGridWebApp.Models;
using SimpleCRUDGridWebApp.Services;

namespace SimpleCRUDGridWebApp.Pages
{
    public class AddModel : PageModel
    {
        [BindPropertyAttribute]
        public AddExpenseModel addExpense { get; set; }
        public List<SelectListItem> customers { get; set; }
        public List<SelectListItem> projects { get; set; }
        private ISqlGridData _data;

        public AddModel(ISqlGridData data)
        {
            _data = data;
        }

        public JsonResult TestJson()
        {
        	return new JsonResult(_data.GetCustomers());
        }

        private void FillDropDownLists(int? cid)
        {
            customers = new List<SelectListItem>();
            customers.Clear();
            customers.Add(new SelectListItem
            {
                Text = "Select a customer"
            });
            foreach (var e in _data.GetCustomers())
            {
                customers.Add(new SelectListItem
                {
                    Value = e.CustomerId.ToString(),
                    Text = e.CustomerName
                });
            }

            projects = new List<SelectListItem>();
            projects.Clear();
            projects.Add(new SelectListItem
            {
                Text = "Select a project"
            });

            if (cid != null)
            {
                foreach (var x in _data.GetProjects(cid.Value))
                {
                    projects.Add(new SelectListItem
                    {
                        Value = x.ProjectId.ToString(),
                        Text = x.ProjectName
                    });
                }
            }
        }
        //addExpense.Project.Customer.CustomerId = cid;


        public IActionResult OnGet(int? id)
        {
            //int customerId = cid == null ? addExpense.Project.Customer.CustomerId : cid.Value;
            FillDropDownLists(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            Expense newExpense = new Expense();
            newExpense.ExpenseDate = addExpense.ExpenseDate;
            newExpense.ExpenseName = addExpense.ExpenseName;
            newExpense.Amount = addExpense.ExpenseAmount;
            newExpense.Description = addExpense.ExpenseDescription;
            newExpense.Project.ProjectId = addExpense.ProjectId;
            newExpense.Project.Customer.CustomerId = addExpense.CustomerId;

            _data.AddExpense(newExpense);
            return RedirectToAction("Index", "Home");
        }
    }
}