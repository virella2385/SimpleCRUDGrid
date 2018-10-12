using SimpleCRUDGridWebApp.Models;
using System.Collections.Generic;

namespace SimpleCRUDGridWebApp.Services
{
    public interface ISqlGridData
    {
    	IEnumerable<Expense> GetExpenses();
    	IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetProjects(int id);
    	IEnumerable<Customer> GetCustomers();
    	Expense GetExpense(int id);
    	Expense UpdateExpense(Expense newExpense);
        Expense AddExpense(Expense newExpense);
    }
}