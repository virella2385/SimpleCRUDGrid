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
        private ISqlGridData _data;
        private List<SelectListItem> _customers, _projects;

        public EditController(ISqlGridData data)
        {
            _data = data;
        }

        public IActionResult Index(int id)
        {
            EditExpenseVM editExpense = new EditExpenseVM();

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

            FillDropDownLists(ref _customers, ref _projects, editExpense.customerId);

            editExpense.customers = _customers;
            editExpense.projects = _projects;

            return View(editExpense);
        }

        private void FillDropDownLists(ref List<SelectListItem> customers, ref List<SelectListItem> projects, int id)
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
            projects.Add(new SelectListItem { Text = "Select a project" });
            foreach (Project proj in _data.GetProjects(id))
            {
                projects.Add(new SelectListItem
                {
                    Text = proj.ProjectName,
                    Value = proj.ProjectId.ToString()
                });
            }
        }

        [HttpPostAttribute]
        public IActionResult SaveForm(EditExpenseVM editExpense, string btnSave)
        {
            if (ModelState.IsValid)
            {
                Expense modifiedExpense = new Expense();
                modifiedExpense = _data.GetExpense(editExpense.expenseId);
                modifiedExpense.Amount = editExpense.expenseAmount;
                modifiedExpense.ExpenseName = editExpense.expenseName;
                modifiedExpense.ExpenseId = editExpense.expenseId;
                modifiedExpense.Description = editExpense.expenseDescription;
                modifiedExpense.ProjectId = editExpense.projectId;

                _data.UpdateExpense(modifiedExpense);

                if (btnSave.ToLower() == "save")
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            FillDropDownLists(ref _customers, ref _projects, editExpense.customerId);
            editExpense.customers = _customers;
            editExpense.projects = _projects;

            return View("Index", editExpense);
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