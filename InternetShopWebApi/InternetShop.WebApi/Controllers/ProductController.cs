using Microsoft.AspNetCore.Mvc;
using InternetShop.Contract.DTO;
using InternetShop.Services.Interfaces;
using InternetShop.Services.Exceptions;

namespace InternetShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
		{
			var products = await _productService.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDto>> GetById(int id)
		{
			var product = await _productService.GetByIdAsync(id);
			if (product == null) return NotFound();
			return Ok(product);
		}

		[HttpGet("category/{categoryId}")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory(int categoryId)
		{
			var products = await _productService.GetByCategoryAsync(categoryId);
			return Ok(products);
		}

		[HttpPost]
		public async Task<ActionResult<ProductDto>> Create([FromBody] ProductDto dto)
		{
			try
			{
				var created = await _productService.CreateAsync(dto);
				return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] ProductDto dto)
		{
			try
			{
				var updated = await _productService.UpdateAsync(id, dto);
				if (updated == null) return NotFound();
				return Ok(updated);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var result = await _productService.DeleteAsync(id);
				if (!result) return NotFound();
				return NoContent();
			}
			catch (ValidationException ex)
			{
				return BadRequest(new { error = ex.Message });
			}
			catch (NotFoundException ex)
			{
				return NotFound(new { error = ex.Message });
			}
		}
	}
}
