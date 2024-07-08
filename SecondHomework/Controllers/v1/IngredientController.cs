using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecondHomework.Core.Application.Core;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Interfaces.Contracts;

namespace SecondHomework.Presentation.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	[Authorize(Roles = "Admin")]
	public class IngredientController : BaseController
	{

		private readonly IIngredientService _ingredientService;

		public IngredientController(IIngredientService ingredientService)
		{

			_ingredientService = ingredientService;
		}

		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAll()
		{
			Result<List<GetIngridientDto>> IngredientResult = await _ingredientService.GetAllAsync();
			try
			{
				if (IngredientResult.Data == null || IngredientResult.Data.Count == 0)
				{
					return NoContent();
				}


				return Ok(IngredientResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDishDto))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetById(Guid id)
		{
			Result<GetIngridientDto> IngredientResult = await _ingredientService.GetByIdAsync(id);
			try
			{
				if (IngredientResult.Data == null)
				{
					return NoContent();
				}

				return Ok(IngredientResult);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("Add")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SaveDishDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Post(SaveIngridientDto saveDto)
		{

			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<SaveIngridientDto> IngridientResult = await _ingredientService.SaveAsync(saveDto);

				//	var locationUrl = Url.Action("GetById", "DishController", new { id = DishResult.Data.Id }, Request.Scheme);
				//return Created(locationUrl ,DishResult);

				return StatusCode(StatusCodes.Status201Created, IngridientResult);
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
		public async Task<IActionResult> Put(UpdateIngridientDto updateDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest();
				}

				Result<UpdateIngridientDto> OrderResult = await _ingredientService.UpdateAsync(updateDto);

				return Ok();
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
				Result<GetIngridientDto> OrderResult = await _ingredientService.DeleteAsync(id);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

			}
		}
	}
}
