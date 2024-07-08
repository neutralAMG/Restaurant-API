using AutoMapper;
using SecondHomework.Core.Application.Dtos.EntitiesDtos;
using SecondHomework.Core.Application.Dtos.SubEntitiesDto;
using SecondHomework.Core.Domain.Entities;


namespace SecondHomework.Core.Application.Utils.Mapper
{
	public class GeneeralProfile : Profile
	{
		public GeneeralProfile()
		{
			#region Dish mappings configuration profiles

			CreateMap<Dish, GetDishDto>()
				.ForMember(desc => desc.DishCategory, opt => opt.MapFrom(d => d.DishCategory))
				.ForMember(desc => desc.OrderDishes, opt => opt.MapFrom(opt => opt.OrderDishes))
				.ReverseMap()
				.ForMember(desc => desc.DishCategoryId, opt => opt.Ignore());

			CreateMap<Dish, SaveDishDto>()
				.ReverseMap()
				.ForMember(desc => desc.DishCategory, opt => opt.Ignore())
				.ForMember(desc => desc.Id, opt => opt.Ignore())
				.ForMember(desc => desc.OrderDishes, opt => opt.Ignore());

			CreateMap<Dish, UpdateDishDto>()
				.ReverseMap()
				.ForMember(desc => desc.DishCategory, opt => opt.Ignore())
				.ForMember(desc => desc.OrderDishes, opt => opt.Ignore());
			#endregion

			#region DishIngridient mappings configuration profiles

			CreateMap<DishIngridient, GetDishIngridientDto>()
			   .ForMember(desc => desc.Ingredient, opt => opt.MapFrom(opt => opt.Ingredient))
			   .ReverseMap()
			   .ForMember(desc => desc.IngridientId, opt => opt.Ignore())
			   .ForMember(desc => desc.DishId, opt => opt.Ignore());

			CreateMap<DishIngridient, SaveDishIngredientDto>()
	          .ReverseMap()
	          .ForMember(desc => desc.Dish, opt => opt.Ignore())
	          .ForMember(desc => desc.Ingredient, opt => opt.Ignore());

			CreateMap<DishIngridient, UpdateDishIngredientDto>()
              .ReverseMap()
              .ForMember(desc => desc.Dish, opt => opt.Ignore())
              .ForMember(desc => desc.Ingredient, opt => opt.Ignore());

			#endregion

			#region Ingridient mappings configuration profiles

			CreateMap<Ingredient, GetIngridientDto>()
			   .ForMember(desc => desc.DishIngridients, opt => opt.MapFrom(d => d.DishIngridients))
			   .ReverseMap();

			CreateMap<Ingredient, SaveIngridientDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.DishIngridients, opt => opt.Ignore())
			  .ForMember(desc => desc.Id, opt => opt.Ignore());

			CreateMap<Ingredient, UpdateIngridientDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.DishIngridients, opt => opt.Ignore());

			#endregion

			#region OrderDish mappings configuration profiles

			CreateMap<OrderDish, GetOrderDishDto>()
			   .ForMember(desc => desc.Dish, opt => opt.MapFrom(d => d.Dish))
			   .ReverseMap()
			   .ForMember(desc => desc.OrderId, opt => opt.Ignore())
			   .ForMember(desc => desc.DishId, opt => opt.Ignore());

			CreateMap<OrderDish, SaveOrderDishDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.Dish, opt => opt.Ignore())
			  .ForMember(desc => desc.Id, opt => opt.Ignore())
			  .ForMember(desc => desc.Order, opt => opt.Ignore());

			CreateMap<OrderDish, UpdateOrderDishDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.Dish, opt => opt.Ignore())
			  .ForMember(desc => desc.Order, opt => opt.Ignore());

			#endregion

			#region Table mappings configuration profiles

			CreateMap<Table, GetTableDto>()
			   .ForMember(desc => desc.TableState, opt => opt.MapFrom(d => d.TableState))
			   .ForMember(desc => desc.Orders, opt => opt.MapFrom(opt => opt.Orders))
			   .ReverseMap()
			   .ForMember(desc => desc.TableStateId, opt => opt.Ignore());

			CreateMap<Table, SaveTableDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.TableState, opt => opt.Ignore())
			  .ForMember(desc => desc.Orders, opt => opt.Ignore());

			CreateMap<Table, UpdateTableDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.TableState, opt => opt.Ignore())
			  .ForMember(desc => desc.Orders, opt => opt.Ignore());

			#endregion

			#region Order mappings configuration profiles

			CreateMap<Order, GetOrderDto>()
			   .ForMember(desc => desc.Table, opt => opt.MapFrom(d => d.Table))
			   .ForMember(desc => desc.OrderDishes, opt => opt.MapFrom(opt => opt.OrderDishes))
			   .ReverseMap()
			   .ForMember(desc => desc.TableThatOrderIsFor, opt => opt.Ignore());

			CreateMap<Order, SaveOrderDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.Table, opt => opt.Ignore())
			  .ForMember(desc => desc.Id, opt => opt.Ignore())
			  .ForMember(desc => desc.OrderDishes, opt => opt.Ignore());

			CreateMap<Order, UpdateOrderDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.Table, opt => opt.Ignore())
			  .ForMember(desc => desc.OrderDishes, opt => opt.Ignore());

			#endregion

			#region TableState mappings configuration profiles

			CreateMap<TableState, GetTableStateDto>()
			   .ReverseMap()
			   .ForMember(desc => desc.Tables, opt => opt.Ignore());

				CreateMap<TableState, SaveTableStateDto>()
			   .ReverseMap()
			   .ForMember(desc => desc.Tables, opt => opt.Ignore());
			#endregion

			#region DishCategory mappings configuration profiles

			CreateMap<DishCategory, GetDishCategoryDto>()
			   .ReverseMap()
			   .ForMember(desc => desc.Dishes, opt => opt.Ignore());

			CreateMap<DishCategory, SaveDishCategoryDto>()
			  .ReverseMap()
			  .ForMember(desc => desc.Dishes, opt => opt.Ignore())
			  .ForMember(desc => desc.Id, opt => opt.Ignore());
			#endregion
		}
	}
}
