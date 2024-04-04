using ECommerceAPI.Application.Repositories.ProductRepos;
using ECommerceAPI.Domain.Entities;
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
		public async Task Get()
		{
			var p = await _productReadRepository.GetByIdAsync("04b5b2eb-f7ca-461a-a6d9-ff6ca80c7b91");
			 _productWriteRepository.Update(p);
			_productWriteRepository.SaveAsync();
		}

	}
}
