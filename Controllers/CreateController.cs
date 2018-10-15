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
		private List<SelectListItem> _customers, _projects;

        public CreateController(ISqlGridData data)
        {
            _data = data;
        }

        private void FillDropDownLists(ref List<SelectListItem> customers, ref List<SelectListItem> projects, int? id) 
        {
        	customers = new List<SelectListItem>();
            customers.Add(new SelectListItem { Text = "Select a customer" });
            foreach (Customer cust in _data.GetCustomers())
            {
                customers.Add(new SelectListItem
                {
                    Text = cust.CustomerName,
                    Value = cust.CustomerId.ToString()
                });
            }

            projects = new List<SelectListItem>();
            if (id != null)
            {
                projects.Add(new SelectListItem { Text = "Select a project" });
                foreach (Project proj in _data.GetProjects(id.Value))
                {
                    projects.Add(new SelectListItem
                    {
                        Text = proj.ProjectName,
                        Value = proj.ProjectId.ToString()
                    });
                }
            }
            else
            {
                projects.Add(new SelectListItem { Text = "Select a customer first" });
            }
        }

        public IActionResult Index()
        {
            EditExpenseVM addExpense = new EditExpenseVM();
            addExpense.expenseDate = DateTime.Today.Date;
            addExpense.customers = new List<SelectListItem>();
            addExpense.projects = new List<SelectListItem>();

            FillDropDownLists(ref _customers, ref _projects, null);

            addExpense.customers = _customers;
            addExpense.projects = _projects;

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
                else
                {
                	return RedirectToAction("Index", "Create");
                }
            }
            else
            {
            	FillDropDownLists(ref _customers, ref _projects, addedExpense.customerId);
            	addedExpense.customers = _customers;
            	addedExpense.projects = _projects;
                return View("Index", addedExpense);
            }
        }
    }
}