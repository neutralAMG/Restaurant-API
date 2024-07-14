using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;

namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class TableController : BaseController
	{
		private readonly ITableService _tableService;

		public TableController(ITableService tableService)
		{
			_tableService = tableService;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTableDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles ="Admin,waiter")]
		public async Task<IActionResult> GetAll()
		{
			Result<List<GetTableDto>> TableResult = await _tableService.GetAllAsync();
			try
			{
				if (TableResult.Data == null || TableResult.Data.Count == 0)
				{
					return NoContent();
				}


				return Ok(TableResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("GetById{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTableDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles ="Admin,waiter")]
		public async Task<IActionResult> GetById(Guid id)
		{
			Result<GetTableDto> TableResult = await _tableService.GetByIdAsync(id);
			try
			{
				if (TableResult.Data == null)
				{
					return NoContent();
				}

				return Ok(TableResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("Edit{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles ="waiter")]
		public async Task<IActionResult> ChangeTableStatus(Guid id, int status)
		{
			Result<GetTableDto> TableResult = await _tableService.ChangeTableStatusAsync(id, status);
			try
			{
				if (TableResult.Data == null)
				{
					return NoContent();
				}

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpGet("GetTableOrder/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles ="waiter")]
		public async Task<IActionResult> GetTableOrder(Guid id)
		{
			Result<GetOrderDto> TableResult = await _tableService.GetTableOrderAsync(id);
			try
			{
				if (TableResult.Data == null)
				{
					return NoContent();
				}

				return Ok(TableResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		[HttpPost("Add")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaveTableDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Post(SaveTableDto saveDto)
		{

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveTableDto> TableResult = await _tableService.SaveAsync(saveDto);

				//	var locationUrl = Url.Action("GetById", "DishController", new { id = DishResult.Data.Id }, Request.Scheme);
				//return Created(locationUrl ,DishResult);

				return StatusCode(StatusCodes.Status201Created, TableResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut("Edit")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> Put(UpdateTableDto updateDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<UpdateTableDto> TableResult = await _tableService.UpdateAsync(updateDto);

				return Ok(TableResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}
		[HttpDelete("Delete/{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				Result<GetTableDto> TableResult = await _tableService.DeleteAsync(id);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}
	}
}
