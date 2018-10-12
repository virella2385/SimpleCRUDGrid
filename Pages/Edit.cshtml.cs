using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUDGridWebApp.Models;
using SimpleCRUDGridWebApp.Services;

namespace SimpleCRUDGridWebApp.Pages
{
    public class EditModel : PageModel
    {
        [BindPropertyAttribute]
        public Expense editExpense { get; set; }

    /*    [BindPropertyAttribute]
        public int isApply { get; set; }*/

        public List<SelectListItem> customers { get; set; }
        public List<SelectListItem> projects { get; set; }

        /*    [BindPropertyAttribute]
            public string selectedCustomer { get; set; }

            [BindPropertyAttribute]
            public string selectedProject { get; set; }*/
        //public List<SelectListItem> ddl { get; set; }

        private ISqlGridData _data;

        /* public EditModel(ISqlGridData data)
         {
             _data = data;
         }*/

        public EditModel(ISqlGridData data)
        {
            _data = data;
        }

        private void FillDropDownLists(int cid)
        {
        	//editExpense.Project.Customer.CustomerId = cid;

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

            //int customerId = cid == null ? editExpense.Project.Customer.CustomerId : cid.Value;

            projects = new List<SelectListItem>();
            projects.Clear();
            projects.Add(new SelectListItem
            {
                Text = "Select a project"
            });
            foreach (var x in _data.GetProjects(cid))
            {
                projects.Add(new SelectListItem
                {
                    Value = x.ProjectId.ToString(),
                    Text = x.ProjectName
                });
            }
            editExpense.Project.Customer.CustomerId = cid;

        }

        public IActionResult OnGet(int id, int? cid)
        {
            //System.Console.WriteLine("id: " + id.ToString());
            /*Expense currentExpense = new Expense();
        	currentExpense = _context.Expenses.FirstOrDefault(e => e.ExpenseId == id);*/
            //currentExpense = _data.Get(1);
            /*	if (currentExpense == null)
                {
                    return RedirectToAction("Index", "Home");
                }*/
            editExpense = _data.GetExpense(id);
            //editExpense.Project.Customer.CustomerId = cid == null ? editExpense.Project.Customer.CustomerId : cid.Value;
            //currentExpense = _data.GetExpense(1).ExpenseDate;
            //editExpense.expenseDate = currentExpense.ExpenseDate;
            int customerId = cid == null ? editExpense.Project.Customer.CustomerId : cid.Value;
            FillDropDownLists(customerId);
            /* customers = new List<SelectListItem>();
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

             int customerId = cid == null ? editExpense.Project.Customer.CustomerId : cid.Value;

             projects = new List<SelectListItem>();
             projects.Add(new SelectListItem
             {
                 Text = "Select a project"
             });
             foreach (var e in _data.GetProjects(customerId))
             {
                 projects.Add(new SelectListItem
                 {
                     Value = e.ProjectId.ToString(),
                     Text = e.ProjectName
                 });
             }*/
            return Page();
        }

        public IActionResult OnPost(int isApply)
        {
            if (ModelState.IsValid)
            {
                switch (isApply)
                {
                    case 1:
                        _data.UpdateExpense(editExpense);
                        return RedirectToPage();
                    case 0:
                        _data.UpdateExpense(editExpense);
                        return RedirectToAction("Index", "Home");
                }

            }
            FillDropDownLists(editExpense.Project.Customer.CustomerId);
            /*        customers = new List<SelectListItem>();
                    customers.Add(new SelectListItem
                    {
                        Text = "Select a customer",
                        Value = "0"
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
                    projects.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = "Select a project"
                    });
                    foreach (var e in _data.GetProjects())
                    {
                        projects.Add(new SelectListItem
                        {
                            Value = e.ProjectId.ToString(),
                            Text = e.ProjectName
                        });
                    }
        */            //return RedirectToPage();
            return Page();
            //return BadRequest(ModelState.ErrorCount);
        }
    }
}