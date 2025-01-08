using Microsoft.AspNetCore.Mvc;
using InternetShop.Services.Interfaces;
using InternetShop.Contract.DTO;
using InternetShop.Services.Exceptions;

namespace InternetShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
		{
			var categories = await _categoryService.GetAllAsync();
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryDto>> GetById(int id)
		{
			var category = await _categoryService.GetByIdAsync(id);
			if (category == null) return NotFound();
			return Ok(category);
		}

		[HttpPost]
		public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryDto dto)
		{
			var created = await _categoryService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] CategoryDto dto)
		{
			var updated = await _categoryService.UpdateAsync(id, dto);
			if (updated == null) return NotFound();
			return Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var success = await _categoryService.DeleteAsync(id);
				if (!success) return BadRequest("Unknown error");
				return NoContent();
			}
			catch (NotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (ValidationException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
