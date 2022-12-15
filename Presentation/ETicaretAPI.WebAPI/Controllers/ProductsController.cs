using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;   
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productReadRepository.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            _productWriteRepository.AddAsync(product);
            return Ok();
        }
    }
}
