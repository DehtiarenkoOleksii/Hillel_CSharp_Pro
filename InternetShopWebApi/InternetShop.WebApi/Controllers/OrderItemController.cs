using Microsoft.AspNetCore.Mvc;
using InternetShop.Services.Interfaces;
using InternetShop.Contract.DTO;

namespace InternetShop.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderItemController : ControllerBase
	{
		private readonly IOrderItemService _orderItemService;

		public OrderItemController(IOrderItemService orderItemService)
		{
			_orderItemService = orderItemService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAll()
		{
			var items = await _orderItemService.GetAllAsync();
			return Ok(items);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OrderItemDto>> GetById(int id)
		{
			var item = await _orderItemService.GetByIdAsync(id);
			if (item == null) return NotFound();
			return Ok(item);
		}

		[HttpPost]
		public async Task<ActionResult<OrderItemDto>> Create([FromBody] OrderItemDto dto)
		{
			try 
			{
				var created = await _orderItemService.CreateAsync(dto);
				return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<OrderItemDto>> Update(int id, [FromBody] OrderItemDto dto)
		{
			try
			{
				var updated = await _orderItemService.UpdateAsync(id, dto);
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
			var success = await _orderItemService.DeleteAsync(id);
			if (!success) return NotFound();
			return NoContent();
		}

		[HttpGet("order/{orderId}")]
		public async Task<IActionResult> GetByOrderId(int orderId)
		{
			var orderItems = await _orderItemService.GetByOrderIdAsync(orderId);
			return Ok(orderItems);
		}
	}
}
