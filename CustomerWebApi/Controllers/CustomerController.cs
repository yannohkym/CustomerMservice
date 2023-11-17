using CustomerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CustomerWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly CustomerDbContext _customerDbContext;

		public CustomerController(CustomerDbContext customerDbContext)
		{
			_customerDbContext = customerDbContext;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Customer>> getCustomers(){

			return _customerDbContext.customers;
        }
		[HttpGet("{customerId:int}")]
		public async Task<ActionResult<Customer>> GetById(int customerId) { 
		var customer = await _customerDbContext.customers.FindAsync(customerId);
	    return customer;

		
		}
		[HttpPost]
		public async Task<ActionResult> create(Customer customer)
		{
			await _customerDbContext.customers.AddAsync(customer);
			await _customerDbContext.SaveChangesAsync();
			return Ok();
		}
		[HttpPut]
		public  async Task<ActionResult> update(Customer customer)
		{
			 _customerDbContext.customers.Update(customer);
			await _customerDbContext.SaveChangesAsync();
			return Ok();
		}
		[HttpDelete("{customerId:int}")]
		public async Task<ActionResult> delete(int  customerId)
		{
			var retrievedcustomer = _customerDbContext.customers.Find(customerId);
			_customerDbContext.customers.Remove(retrievedcustomer);
			await _customerDbContext.SaveChangesAsync();
			return Ok();
		}

	}
}
