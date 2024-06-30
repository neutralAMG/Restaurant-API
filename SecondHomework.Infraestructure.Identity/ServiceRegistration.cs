using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHomework.Infraestructure.Identity.Context;
using SecondHomework.Infraestructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHomework.Infraestructure.Identity
{
	public static class ServiceRegistration
	{
		public static void AddIdentityInfraestructureLayer(this IServiceCollection services, IConfiguration config) {

			services.AddDbContext<IdentityContext>(opti => opti.UseSqlServer(config.GetConnectionString("IdentityConnection"), m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));


			services.AddIdentity<AplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

			services.AddAuthentication();
		
		}
	}
}
