using JQueryDataTable.Models;
using JQueryDataTable.Services;
using Microsoft.AspNetCore.Mvc;

namespace JQueryDataTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomers()
        {
            var request = new DataTableRequest
            {
                Start = int.Parse(Request.Form["start"]),
                Length = int.Parse(Request.Form["length"]),
                SearchValue = Request.Form["search[value]"],
                SortColumn = Request.Form[$"columns[{Request.Form["order[0][column]"]}][name]"],
                SortDirection = Request.Form["order[0][dir]"]
            };

           
            var totalRecords = await _customerService.GetTotalCountAsync();

            
            var filteredQuery = _customerService.GetFilteredCustomers(request.SearchValue);

           
            var filteredRecords = await _customerService.GetFilteredCountAsync(filteredQuery);

            
            var sortedQuery = _customerService.ApplySorting(filteredQuery, request.SortColumn, request.SortDirection);

           
            var data = await _customerService.GetPagedDataAsync(sortedQuery, request.Start, request.Length);

           
            return Ok(new
            {
                recordsTotal = totalRecords,
                recordsFiltered = filteredRecords,
                data
            });
        }
    }
}
