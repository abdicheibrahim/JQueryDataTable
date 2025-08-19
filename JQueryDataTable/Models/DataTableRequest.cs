namespace JQueryDataTable.Models
{
    public class DataTableRequest
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
