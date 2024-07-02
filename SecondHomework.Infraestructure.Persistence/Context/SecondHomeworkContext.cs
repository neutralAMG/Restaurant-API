

using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Infraestructure.Persistence.Context
{
	public class SecondHomeworkContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Table> Tables { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }

		public DbSet<OrderDish> OrderDishes { get; set; }
		public DbSet<DishIngridient> DishIngridients { get; set; }
		public DbSet<TableState> TableStates { get; set; }
		public DbSet<DishCategory> DishCategories { get; set; }

        public SecondHomeworkContext(DbContextOptions<SecondHomeworkContext> options) : base (options)
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=SecondHomework; Integrated Security=true; TrustServerCertificate=true;"
				, m => m.MigrationsAssembly(typeof(SecondHomeworkContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
