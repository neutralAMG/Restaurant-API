using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondHomework.Infraestructure.Identity.Entities;


namespace SecondHomework.Infraestructure.Identity.Context
{
	public class IdentityContext : IdentityDbContext<AplicationUser>
	{

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
           
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-LL4GL68; Database=SecondHomework; Integrated Security=true; TrustServerCertificate=true;", m => m.MigrationsAssembly("SecondHomework.Infraestructure.Identity"));
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.HasDefaultSchema("Identity");

			builder.Entity<AplicationUser>(entity =>
			{
				entity.ToTable(name: "User");
			});

			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Rolls");
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable(name: "UserRolls");
			});

			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable(name: "UserLogins");
			});
		}
	}
}
