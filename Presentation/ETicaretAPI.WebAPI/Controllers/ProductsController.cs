﻿using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

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

        [HttpGet()]
        public IActionResult GetAll([FromQuery] Pagination? pagination)
        {           
            int totalCount = _productReadRepository.GetAll(false).Count();

            //var result = pagination.Page == 0 && pagination.Size == 0
            //    ? _productReadRepository.GetAll(false).OrderBy(i=>i.Id).Select(p => new
            //    {
            //        p.Id,
            //        p.Name,
            //        p.Stock,
            //        p.Price,
            //        p.CreatedDate,
            //        p.UpdatedDate
            //    }):
            
           var products = _productReadRepository.GetAll(false).OrderBy(i => i.Id).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate
                });

           Console.WriteLine($"{DateTime.Now}\nToplam Veri Sayısı:{totalCount}\n");

            return Ok(new { totalCount, products});
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productReadRepository.GetByIdAsync(id,false);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Add(VM_Create_Product product)
        {
           
           await _productWriteRepository.AddAsync(new()
           {
               Name = product.ProductName,
               Price= product.Price,
               Stock= product.Stock,
               CreatedDate = DateTime.UtcNow
               
           });
            return StatusCode((int)HttpStatusCode.Created);
        }

        //[HttpPost("addrange")]
        //public async Task<IActionResult> AddRange(List<Product> products)
        //{
        //    var result = await _productWriteRepository.AddRangeAsync(products);
        //    return Ok(result);
        //}

        [HttpPut()]
        public async Task<IActionResult> Update(VM_Update_Product product)
        {
            Product updateProduct = await _productReadRepository.GetByIdAsync(product.Id);
            updateProduct.Name = product.ProductName ?? updateProduct.Name;
            updateProduct.Price = product.Price == 0 ? updateProduct.Price: product.Price;
            updateProduct.Stock = product.Stock == 0 ? updateProduct.Stock : product.Stock;

            _productWriteRepository.Update(updateProduct);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productWriteRepository.RemoveAsync(id);
            return Ok();
        }
    }
}
