using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;

namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	[Authorize(Roles = "Admin, waiter")]
	public class OrderController : BaseController
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			Result<List<GetOrderDto>> OrderResult = await _orderService.GetAllAsync();
			try
			{
				if (OrderResult.Data == null || OrderResult.Data.Count == 0)
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

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetById(Guid id)
		{
			Result<GetOrderDto> OrderResult = await _orderService.GetByIdAsync(id);
			try
			{
				if (OrderResult.Data == null )
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
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaveOrderDto))]
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
		[ProducesResponseType(StatusCodes.Status204NoContent)]
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

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		
		public async Task<IActionResult> Delete(Guid id)
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
