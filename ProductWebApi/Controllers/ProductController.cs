using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductDbContext _productDbContext;

		public ProductController(ProductDbContext productDbContext)
		{
			_productDbContext = productDbContext;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Product>> getProducts()
		{

			return _productDbContext.products;
		}
		[HttpGet("{productId:int}")]
		public async Task<ActionResult<Product>> GetById(int productId)
		{
			var product = await _productDbContext.products.FindAsync(productId);
			return product;


		}
		[HttpPost]
		public async Task<ActionResult> create(Product product)
		{
			await _productDbContext.products.AddAsync(product);
			await _productDbContext.SaveChangesAsync();
			return Ok();
		}
		[HttpPut]
		public async Task<ActionResult> update(Product product)
		{
			_productDbContext.products.Update(product);
			await _productDbContext.SaveChangesAsync();
			return Ok();
		}
		[HttpDelete("{productId:int}")]
		public async Task<ActionResult> delete(int productId)
		{
			var retrievedproduct = _productDbContext.products.Find(productId);
			_productDbContext.products.Remove(retrievedproduct);
			await _productDbContext.SaveChangesAsync();
			return Ok();
		}
	}
}
