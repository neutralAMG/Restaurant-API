using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;



namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class DishController : BaseController
	{
		private readonly IDishService _dishService;

		public DishController(IDishService dishService)
		{
			_dishService = dishService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			Result<List<GetDishDto>> DishResult = await _dishService.GetAllAsync();
			try
			{
				if (DishResult.Data == null)
				{
					return NotFound();
				}
				else if (DishResult.Data.Count == 0)
				{
					return NoContent();
				}
				return Ok(DishResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetById(Guid id)
		{
			Result<GetDishDto> DishResult = await _dishService.GetByIdAsync(id);
			try
			{
				if (DishResult.Data == null)
				{
					return NoContent();
				}

				return Ok(DishResult);
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
		public async Task<IActionResult> Post(SaveDishDto saveDto)
		{

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveDishDto> DishResult = await _dishService.SaveAsync(saveDto);

				//	var locationUrl = Url.Action("GetById", "DishController", new { id = DishResult.Data.Id }, Request.Scheme);
				//return Created(locationUrl ,DishResult);

				return StatusCode(StatusCodes.Status201Created, DishResult);
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
		public async Task<IActionResult> Put(int operation, SaveDishIngredientDto saveDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveDishDto> DishResult = await _dishService.UpdateDishAsync(operation, saveDto);

				return Ok(DishResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}

	}
}
