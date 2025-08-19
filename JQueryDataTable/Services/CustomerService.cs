using JQueryDataTable.Data;
using JQueryDataTable.Models;
using Microsoft.EntityFrameworkCore;

namespace JQueryDataTable.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetFilteredCustomers(string? searchValue)
        {
            return _context.Customers.Where(c =>
                string.IsNullOrEmpty(searchValue) ||
                c.FirstName.Contains(searchValue) ||
                c.LastName.Contains(searchValue) ||
                c.Contact.Contains(searchValue) ||
                c.Email.Contains(searchValue));
        }

        public IQueryable<Customer> ApplySorting(IQueryable<Customer> query, string? sortColumn, string? sortDirection)
        {
            // الأعمدة المسموحة فقط (حماية من SQL Injection)
            var allowedColumns = new[] { "Id", "FirstName", "LastName", "Contact", "Email", "DateOfBirth" };

            if (!string.IsNullOrEmpty(sortColumn) && allowedColumns.Contains(sortColumn))
            {
                query = sortDirection == "desc"
                    ? query.OrderByDescending(x => EF.Property<object>(x, sortColumn))
                    : query.OrderBy(x => EF.Property<object>(x, sortColumn));
            }

            return query;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<int> GetFilteredCountAsync(IQueryable<Customer> query)
        {
            return await query.CountAsync();
        }

        public async Task<List<Customer>> GetPagedDataAsync(IQueryable<Customer> query, int start, int length)
        {
            return await query.Skip(start).Take(length).ToListAsync();
        }
    }
}
