using System;
using System.Collections.Generic;
using CustomerAPI.DataContext;
using Data.Contracts;
using Data.Filter;
using Data.Implementation;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IAppService _appService;

        public CustomersController(IAppService appService)
        {
            _appService = appService;
        }

        // /api/customers
        [HttpGet]
        public ActionResult<Customer> GetCustomers([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = _appService.Count();

            var customers = _appService.GetAll(validFilter, totalRecords);
            if (customers == null)
            {
                return BadRequest(new PagedResponse<Customer>(validFilter, totalRecords));
            }
            return Ok(new PagedResponse<IEnumerable<Customer>>(customers, validFilter, totalRecords));
        }

        // Json dosyadaki verilerin idleri 1000'den sonra tekrar ettiği için react tarafında arama yaptıktan sonra
        // edit butonuna basınca dataları boş getirebiliyor
        // /api/customers/1
        [HttpGet("{id}", Name = "Search")]
        public IActionResult GetById(int id)
        {
            var customer = _appService.FindById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(new Response<Customer>(customer));
        }

        // /api/customers/search?name=linet
        [HttpGet("search")]
        public ActionResult<Customer> Search(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest(new Response<Customer>());
            }
            var customers = _appService.FindByName(name);
            var totalCount = _appService.CountSearchedCustomers(name);
            return Ok(new PagedResponse<IEnumerable<Customer>>(customers, null, totalCount));
        }

        // /api/customers/create
        [HttpPost("create")]
        public IActionResult Create(Customer customer)
        {
            _appService.Add(customer);
            return Ok(customer);
        }

        // /api/customers/edit/1
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            _appService.Update(customer);
            return Ok();
        }
    }
}