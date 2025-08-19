using JQueryDataTable.Models;
using Microsoft.EntityFrameworkCore;

namespace JQueryDataTable.Data
{
    public class ApplicationDbContext: DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
       
    }
}
