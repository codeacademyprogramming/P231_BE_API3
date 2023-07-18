using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApp.Service.Dtos.BrandDtos;
using ShopApp.Core.Entities;
using ShopApp.Core.Repositories;
using ShopApp.Service.Interfaces;
using ShopApp.Service.Exceptions;

namespace ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("all")]
        public ActionResult<List<BrandGetAllItemDto>> GetAll()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BrandGetDto> Get(int id)
        {
            return Ok(_brandService.GetById(id));
        }

        [HttpPost("")]
        public IActionResult Create(BrandCreateDto brandDto)
        {
            try
            {
                var result = _brandService.Create(brandDto);
                return StatusCode(201, result);
            }
            catch (EntityDublicateException e)
            {
                ModelState.AddModelError("Name", e.Message);
                return BadRequest(ModelState);
            }
         
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, BrandEditDto brandDto)
        {
            try
            {
                _brandService.Edit(id, brandDto);
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
            catch(EntityDublicateException e)
            {
                ModelState.AddModelError("Name", e.Message);
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _brandService.Remove(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
