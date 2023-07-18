using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data;
using ShopApp.Service.Dtos.ProductDtos;
using ShopApp.Core.Entities;
using ShopApp.Core.Repositories;
using ShopApp.Service.Interfaces;

namespace ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("")]
        public IActionResult Create(ProductCreateDto productDto)
        {
            return StatusCode(201,_productService.Create(productDto));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpGet("all")]
        public ActionResult<List<ProductGetAllItemDto>> GetAll()
        {
           return Ok(_productService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, ProductEditDto productDto)
        {
            _productService.Edit(id, productDto);

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
