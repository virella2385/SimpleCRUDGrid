using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUDGridWebApp.Models;
using SimpleCRUDGridWebApp.Models.ViewModels;
using SimpleCRUDGridWebApp.Services;

namespace SimpleCRUDGridWebApp.Controllers
{
    public class CreateController : Controller
    {
        private ISqlGridData _data;
        public CreateController(ISqlGridData data)
        {
            _data = data;
        }

        public IActionResult Index(int? id)
        {
            EditExpenseVM addExpense = new EditExpenseVM();
            addExpense.expenseDate = DateTime.Today.Date;
            addExpense.customers = new List<SelectListItem>();
            addExpense.customers.Add(new SelectListItem { Text = "Select a customer" });
            foreach (Customer cust in _data.GetCustomers())
            {
                addExpense.customers.Add(new SelectListItem
                {
                    Text = cust.CustomerName,
                    Value = cust.CustomerId.ToString()
                });
            }

            addExpense.projects = new List<SelectListItem>();
            if (id != null)
            {
                addExpense.projects.Add(new SelectListItem { Text = "Select a project" });
                foreach (Project proj in _data.GetProjects(addExpense.customerId))
                {
                    addExpense.projects.Add(new SelectListItem
                    {
                        Text = proj.ProjectName,
                        Value = proj.ProjectId.ToString()
                    });
                }
            }
            else 
            {
            	addExpense.projects.Add(new SelectListItem { Text = "Select a customer first" });
            }

            return View(addExpense);
        }

        public IActionResult SaveForm(EditExpenseVM addedExpense, string btnSave) 
        {
        	if (ModelState.IsValid)
        	{
        		Expense newExpense = new Expense();
        		newExpense.ExpenseName = addedExpense.expenseName;
        		newExpense.ExpenseDate = addedExpense.expenseDate;
        		newExpense.Amount = addedExpense.expenseAmount;
        		newExpense.Description = addedExpense.expenseDescription;
        		newExpense.ProjectId = addedExpense.projectId;

        		_data.AddExpense(newExpense);
        		if (btnSave.ToLower() == "save")
        		{
        			return RedirectToAction("Index", "Home");
        		}
        	}

        	return RedirectToAction("Index", "Create");
        }
    }
}