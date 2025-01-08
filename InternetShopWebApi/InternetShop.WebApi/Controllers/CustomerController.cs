using Microsoft.AspNetCore.Mvc;
using InternetShop.Services.Interfaces;
using InternetShop.Contract.DTO;

namespace InternetShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
		{
			var customers = await _customerService.GetAllAsync();
			return Ok(customers);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerDto>> GetById(int id)
		{
			var customer = await _customerService.GetByIdAsync(id);
			if (customer == null) return NotFound();
			return Ok(customer);
		}

		[HttpPost]
		public async Task<ActionResult<CustomerDto>> Create([FromBody] CustomerDto dto)
		{
			var created = await _customerService.CreateAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<CustomerDto>> Update(int id, [FromBody] CustomerDto dto)
		{
			var updated = await _customerService.UpdateAsync(id, dto);
			if (updated == null) return NotFound();
			return Ok(updated);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var success = await _customerService.DeleteAsync(id);
			if (!success) return NotFound();
			return NoContent();
		}
	}
}
