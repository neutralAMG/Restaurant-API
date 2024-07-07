

using Microsoft.EntityFrameworkCore;
using SecondHomework.Core.Domain.Entities;

namespace SecondHomework.Infraestructure.Persistence.Context
{
	public class SecondHomeworkContext : DbContext
	{

		//public DbSet<User> Users { get; set; }
		public DbSet<Table> Tables { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }

		public DbSet<OrderDish> OrderDishes { get; set; }
		public DbSet<DishIngridient> DishIngridients { get; set; }
		public DbSet<TableState> TableStates { get; set; }
		public DbSet<DishCategory> DishCategories { get; set; }

		public SecondHomeworkContext(DbContextOptions<SecondHomeworkContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=SecondHomework; Integrated Security=true; TrustServerCertificate=true;"
				, m => m.MigrationsAssembly(typeof(SecondHomeworkContext).Assembly.FullName));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Dish>(d =>
			{
				d.HasKey(d => d.Id);

				d.HasOne(d => d.DishCategory)
				.WithMany(d => d.Dishes).IsRequired()
				.HasForeignKey(d => d.DishCategoryId);

				d.HasMany(d => d.DishIngridients)
				.WithOne(d => d.Dish).IsRequired()
				.HasForeignKey(d => d.DishId).OnDelete(DeleteBehavior.Cascade);

				d.HasMany(d => d.OrderDishes).WithOne(d => d.Dish).IsRequired()
				.HasForeignKey(d => d.DishId).OnDelete(DeleteBehavior.Cascade);

				d.HasIndex(d => d.DishCategoryId).IsClustered(false);
				d.HasIndex(d => d.OrderDishes).IsClustered(false);

				d.Property(d => d.AmountOfPeople).IsRequired();
				d.Property(d => d.Price).IsRequired();
				d.Property(d => d.Name).IsRequired();

			});
			modelBuilder.Entity<DishIngridient>(d =>
			{
				d.HasKey(d => d.Id);

				d.HasOne(d => d.Dish)
				.WithMany(d => d.DishIngridients).IsRequired().HasForeignKey(d => d.DishId);

				d.HasOne(d => d.Ingredient)
				.WithMany(d => d.DishIngridients).IsRequired().HasForeignKey(d => d.IngridientId);

				d.HasIndex(d => d.DishId).IsClustered(false);
				d.HasIndex(d => d.IngridientId).IsClustered(false);


			});
			modelBuilder.Entity<Order>(o =>
			{
				o.HasKey(o => o.Id);

				o.HasMany(o => o.OrderDishes)
				.WithOne(o => o.Order).IsRequired().HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Cascade);

				o.HasOne(o => o.Table)
				.WithMany(o => o.Orders).IsRequired().HasForeignKey(o => o.TableThatOrderIsFor).OnDelete(DeleteBehavior.Cascade);

				o.HasIndex(o => o.TableThatOrderIsFor).IsClustered(false);

				o.Property(o => o.SubAmount).IsRequired();
				o.Property(o => o.TableThatOrderIsFor).IsRequired();
				o.Property(o => o.IsCompleted).IsRequired();

			});


			modelBuilder.Entity<OrderDish>(o =>
			{
				o.HasKey(o => o.Id);

				o.HasOne(o => o.Order)
				.WithMany(o => o.OrderDishes).IsRequired().HasForeignKey(o => o.OrderId);

				o.HasOne(o => o.Dish)
				.WithMany(o => o.OrderDishes).IsRequired().HasForeignKey(o => o.DishId);

				o.HasIndex(o => o.OrderId).IsClustered(false);
				o.HasIndex(o => o.DishId).IsClustered(false);

			});
			modelBuilder.Entity<Table>(t =>
			{
				t.HasKey(t => t.Id);

				t.HasMany(t => t.Orders).WithOne(t => t.Table).IsRequired().HasForeignKey(t => t.TableThatOrderIsFor).OnDelete(DeleteBehavior.Cascade);

				t.HasOne(t => t.TableState).WithMany(t => t.Tables).IsRequired().HasForeignKey(t => t.TableStateId);

				t.HasIndex(t => t.TableStateId).IsClustered(false);

				t.Property(t => t.AmountOfPeople).IsRequired();

				t.Property(t => t.Description);


			});
			modelBuilder.Entity<Ingredient>(i =>
			{
				i.HasKey(t => t.Id);

				i.HasMany(i => i.DishIngridients).WithOne(i => i.Ingredient).IsRequired()
				.HasForeignKey(i => i.IngridientId);

				i.Property(i => i.Name);
			});
			modelBuilder.Entity<TableState>(t =>
			{
				t.HasKey(t => t.Id);
				t.HasMany(t => t.Tables).WithOne(t => t.TableState).HasForeignKey(t => t.TableStateId);	
				t.HasData(new TableState { Id = 1, Name = "Avalible" });
				t.HasData(new TableState { Id = 2, Name = "InProcces" });
				t.HasData(new TableState { Id = 3, Name = "Attended" });
			});
			modelBuilder.Entity<DishCategory>(d =>
			{
				d.HasKey(d => d.Id);
				d.HasMany(d => d.Dishes).WithOne(d => d.DishCategory).HasForeignKey(d => d.DishCategoryId);
				d.HasData(new DishCategory { Id = 1, Name = "Entry" });
				d.HasData(new DishCategory { Id = 2, Name = "Strong Dish" });
				d.HasData(new DishCategory { Id = 3, Name = "Dessert" });
				d.HasData(new DishCategory { Id = 4, Name = "beverages" });
			});
		}
	}
}
