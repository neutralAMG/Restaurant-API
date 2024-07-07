using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;

namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class OrderController : BaseController
	{

		
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			Result<List<GetOrderDto>> OrderResult = await _orderService.GetAllAsync();
			try
			{
				if (OrderResult.Data == null)
				{
					return NotFound();
				}
				else if (OrderResult.Data.Count == 0)
				{
					return NoContent();
				}
				return Ok(OrderResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetById(Guid id)
		{
			Result<GetOrderDto> OrderResult = await _orderService.GetByIdAsync(id);
			try
			{
				if (OrderResult.Data == null)
				{
					return NoContent();
				}

				return Ok(OrderResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaveDishDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Post(SaveOrderDto saveDto)
		{

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveOrderDto> OrderResult = await _orderService.SaveAsync(saveDto);

				//	var locationUrl = Url.Action("GetById", "DishController", new { id = DishResult.Data.Id }, Request.Scheme);
				//return Created(locationUrl ,DishResult);

				return StatusCode(StatusCodes.Status201Created, OrderResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveDishDto))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Put(int operation, SaveOrderDishDto saveDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveOrderDto> OrderResult = await _orderService.UpdateOrderAsync(operation, saveDto);

				return Ok(OrderResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}
		[HttpPut("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		
		public async Task<IActionResult> Put(int operation, Guid id)
		{
			try
			{
				Result<GetOrderDto> OrderResult = await _orderService.DeleteAsync(id);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}

	}
}
