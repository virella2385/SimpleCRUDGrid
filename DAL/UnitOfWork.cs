using System;
using SimpleCRUDGridWebApp.Data;
using SimpleCRUDGridWebApp.Models;

namespace SimpleCRUDGridWebApp.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Project> projectRepository;
        private GenericRepository<Expense> expenseRepository;

        public UnitOfWork (ApplicationDbContext context) 
        {
          this.context = context;
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Project> ProjectRepository
        {
            get
            {

                if (this.projectRepository == null)
                {
                    this.projectRepository = new GenericRepository<Project>(context);
                }
                return projectRepository;
            }
        }

         public GenericRepository<Expense> ExpenseRepository
        {
            get
            {

                if (this.expenseRepository == null)
                {
                    this.expenseRepository = new GenericRepository<Expense>(context);
                }
                return expenseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}