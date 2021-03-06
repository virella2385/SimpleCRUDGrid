using Microsoft.EntityFrameworkCore;
using SimpleCRUDGridWebApp.Models;

namespace SimpleCRUDGridWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(p =>
                {
                    p.Property(c => c.Amount).HasColumnType("decimal(18,2)");
                });

            modelBuilder.Entity<Expense>().HasOne(p =>p.Project).WithMany(e => e.Expenses).HasForeignKey(p => p.ProjectId);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}