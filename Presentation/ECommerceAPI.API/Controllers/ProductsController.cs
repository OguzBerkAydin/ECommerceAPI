using ECommerceAPI.Application.Repositories.ProductRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IProductReadRepository _productReadRepository;

		public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
		}
		[HttpGet]
		public async void Get()
		{
			await _productWriteRepository.AddRangeAsync(new()
			{
				new() { CreatedDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10 },
				new() { CreatedDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product2", Price = 200, Stock = 20 },
				new() { CreatedDate = DateTime.UtcNow, Id = Guid.NewGuid(), Name = "Product3", Price = 300, Stock = 30 },
			});
			var count = await _productWriteRepository.SaveAsync();
		}

	}
}
