using Microsoft.AspNetCore.Mvc;
using InternetShop.Services.Interfaces;
using InternetShop.Contract.DTO;

namespace InternetShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
		{
			var orders = await _orderService.GetAllAsync();
			return Ok(orders);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderDto>> GetById(int id)
		{
			var order = await _orderService.GetByIdAsync(id);
			if (order == null) return NotFound();
			return Ok(order);
		}

		[HttpPost]
		public async Task<ActionResult<OrderDto>> Create([FromBody] OrderDto dto)
		{
			try
			{
				var created = await _orderService.CreateAsync(dto);
				return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}


		}

		[HttpPut("{id}")]
		public async Task<ActionResult<OrderDto>> Update(int id, [FromBody] OrderDto dto)
		{
			try
			{
				var updated = await _orderService.UpdateAsync(id, dto);
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
			var success = await _orderService.DeleteAsync(id);
			if (!success) return NotFound();
			return NoContent();
		}

		[HttpGet("{id}/with-items")]
		public async Task<IActionResult> GetByIdWithItems(int id)
		{
			var order = await _orderService.GetByIdWithItemsAsync(id);
			if (order == null)
			{
				return NotFound($"Order with id {id} not found.");
			}
			return Ok(order);
		}

		[HttpGet("customer/{customerId}")]
		public async Task<IActionResult> GetByCustomerId(int customerId)
		{
			var orders = await _orderService.GetByCustomerIdAsync(customerId);
			return Ok(orders);
		}
	}
}
