using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUDGridWebApp.Models;
using SimpleCRUDGridWebApp.Models.ViewModels;
using SimpleCRUDGridWebApp.Services;

namespace SimpleCRUDGridWebApp.Controllers
{
    public class EditController : Controller
    {
        //public List<SelectListItem> customers { get; set; }
        private ISqlGridData _data;

        public EditController(ISqlGridData data)
        {
            _data = data;
        }

        public IActionResult Index(int id)
        {
            EditExpenseVM editExpense = new EditExpenseVM();
            //editExpense = _data.GetExpense(id);

            Expense currentExpense = new Expense();
            currentExpense = _data.GetExpense(id);
            editExpense.customerId = currentExpense.Project.Customer.CustomerId;
            editExpense.projectId = currentExpense.Project.ProjectId;
            editExpense.expenseId = currentExpense.ExpenseId;
            editExpense.expenseName = currentExpense.ExpenseName;
            editExpense.expenseDate = currentExpense.ExpenseDate;
            editExpense.expenseDescription = currentExpense.Description;
            editExpense.expenseAmount = currentExpense.Amount;
            editExpense.customers = new List<SelectListItem>();
            editExpense.projects = new List<SelectListItem>();

            //List<SelectListItem> customers = new List<SelectListItem>();
            editExpense.customers.Add(new SelectListItem { Text = "Select a customer" });
            foreach (Customer cust in _data.GetCustomers())
            {
                editExpense.customers.Add(new SelectListItem
                {
                    Text = cust.CustomerName,
                    Value = cust.CustomerId.ToString()
                });
            }

            //List<SelectListItem> projects = new List<SelectListItem>();
            editExpense.projects.Add(new SelectListItem { Text = "Select a project" });
            foreach (Project proj in _data.GetProjects(editExpense.customerId))
            {
                editExpense.projects.Add(new SelectListItem
                {
                    Text = proj.ProjectName,
                    Value = proj.ProjectId.ToString()
                });
            }
            return View(editExpense);
        }

        [HttpPostAttribute]
        public IActionResult SaveForm(EditExpenseVM editExpense, string btnSave) 
        {
        	if (ModelState.IsValid) {
        		Expense modifiedExpense = new Expense();
        		modifiedExpense = _data.GetExpense(editExpense.expenseId);
        		modifiedExpense.Amount = editExpense.expenseAmount;
        		modifiedExpense.ExpenseName = editExpense.expenseName;
        		modifiedExpense.ExpenseId = editExpense.expenseId;
        		modifiedExpense.Description = editExpense.expenseDescription;
        		modifiedExpense.ProjectId = editExpense.projectId;
        		//modifiedExpense.Project.Customer.CustomerId = editExpense.customerId;
				_data.UpdateExpense(modifiedExpense);

				if (btnSave.ToLower() == "save")
				{
					return RedirectToAction("Index", "Home");
				}
	        	/*switch (btnSave.ToLower())
	        	{
	        		case "save": return RedirectToAction("Index", "Home");
	        			//return new JsonResult("save");
	        		default: return return

	        			//return new JsonResult("apply");
	        	}*/
	        }
	        return RedirectToAction("Index", new { id = editExpense.expenseId });
        }

        [HttpGetAttribute]
        public JsonResult GetProjects(int id)
        {
            return new JsonResult(_data.GetProjects(id));
        }

         [HttpGetAttribute]
        public JsonResult GetExpense()
        {
            return new JsonResult(_data.GetExpense(1));
        }


    }
}