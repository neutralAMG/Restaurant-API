

using Microsoft.EntityFrameworkCore;

namespace SecondHomework.Infraestructure.Persistence.Context
{
	public class SecondHomeworkContext : DbContext
	{
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
