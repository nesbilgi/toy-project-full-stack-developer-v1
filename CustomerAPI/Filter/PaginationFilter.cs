namespace Data.Filter
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 50; // default pageSize
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 200 ? 200 : pageSize;
        }
    }
}