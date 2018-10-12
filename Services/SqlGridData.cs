using System.Linq;
using SimpleCRUDGridWebApp.Data;
using SimpleCRUDGridWebApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleCRUDGridWebApp.Services
{
    public class SqlGridData : ISqlGridData
    {
    	private ApplicationDbContext _context;
    	public SqlGridData (ApplicationDbContext context) 
    	{
    	  _context = context;
    	}

    	public IEnumerable<Expense> GetExpenses() 
    	{
    		return _context.Expenses.Include(e => e.Project).ThenInclude(p => p.Customer);
    	}

    	public IEnumerable<Customer> GetCustomers() 
    	{
    		return _context.Customers;
    	}

    	public IEnumerable<Project> GetProjects() 
    	{
    		return _context.Projects;
    	}

    	public IEnumerable<Project> GetProjects(int id)
    	{
    		return _context.Projects.Where(e => e.Customer.CustomerId == id);
    	}

    	public Expense GetExpense(int id) 
    	{
    		return _context.Expenses.Include(e => e.Project).ThenInclude(p => p.Customer).FirstOrDefault(e => e.ExpenseId == id);
    		//return _context.Expenses.FirstOrDefault(e => e.ExpenseId == id);
    	}

    	public Expense UpdateExpense(Expense newExpense)
    	{
    		_context.Expenses.Attach(newExpense).State = EntityState.Modified;
    		_context.SaveChanges();
    		return newExpense;
    	}

    	public Expense AddExpense(Expense newExpense) 
    	{
    		_context.Expenses.Add(newExpense);
    		_context.SaveChanges();
    		return newExpense;
    	}
    }
}