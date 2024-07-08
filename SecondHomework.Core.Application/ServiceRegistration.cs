

using Microsoft.Extensions.DependencyInjection;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Application.Services;

namespace SecondHomework.Core.Application
{
	public static class ServiceRegistration
	{
		public static void AddAplicationLayer(this IServiceCollection services)
		{
			services.AddTransient<IDishIngredientService, DishIngredientService>();
			services.AddTransient<IDishService, DishService>();
			services.AddTransient<IIngredientService, IngridientService>();
			services.AddTransient<IOrderDishService, OrderDishService>();
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<ITableService, TableService>();
			services.AddTransient<IUserService, UserService>();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}
	}
}
