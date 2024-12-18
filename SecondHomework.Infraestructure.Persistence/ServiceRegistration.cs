﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHomework.Core.Application.Interfaces.Repositories;
using SecondHomework.Infraestructure.Persistence.Context;
using SecondHomework.Infraestructure.Persistence.Repositories;


namespace SecondHomework.Infraestructure.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddInfraestructurePersistanceLayer(this IServiceCollection services,  IConfiguration configuration)
		{

			services.AddDbContext<SecondHomeworkContext>(op => op.UseSqlServer("DefaultConnection",
				m => m.MigrationsAssembly("SecondHomework.Infraestructure.Persistence")));


			services.AddTransient<IDishIngridientRepository, DishIngredientRepository>();
			services.AddTransient<IDishRepository, DishRepository>();
			services.AddTransient<IOrderDishRepository, OrderDishRepository>();
			services.AddTransient<IOrderDishRepository, OrderDishRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<ITableRepository, TableRepository>();
			services.AddTransient<IIngredientRepository, IngredientRepository>();
		}
	}
}
