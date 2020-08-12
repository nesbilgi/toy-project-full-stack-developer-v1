using System;
using System.ComponentModel;
using Data.Filter;

namespace Data.Models
{
    public class PagedResponse<T> : Response<T>
    {
        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(PaginationFilter filter, int totalRecords)
        {
            this.PageNumber = filter.PageNumber;
            this.PageSize = filter.PageSize;
            this.TotalRecords = totalRecords;
            this.TotalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / filter.PageSize));
            this.Message = "Out of boundry";
            this.Succeded = false;
        }

        // Search ve GetCustomers actionlarında dönüş tipi olarak kullanılıyor
        // search actionında filtre kullanılmadığı için pageNumber, pageSize ve totalPage
        // default olarak verilen pageSize(50) göre hesaplanarak api çıktısı olarak veriliyor.
        public PagedResponse(T data, PaginationFilter filter, int totalRecords)
        {
            this.PageNumber = filter != null ? filter.PageNumber : 1;
            this.PageSize = filter != null ? filter.PageSize : totalRecords > 50 ? 50 : totalRecords;
            this.Data = data;
            this.TotalPages = filter != null 
                                ? Convert.ToInt32(Math.Ceiling((double)totalRecords / filter.PageSize)) 
                                : Convert.ToInt32(Math.Ceiling((double)totalRecords / 50));
            this.TotalRecords = totalRecords;
            this.Message = "Succeded";
            this.Succeded = true;
        }
    }
}