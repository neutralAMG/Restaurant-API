using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondHomework.Core.Application.Interfaces.Contracts;
using SecondHomework.Core.Domain.Settings;
using SecondHomework.Infraestructure.Identity.Context;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SecondHomework.Core.Application.Dtos.Account;
namespace SecondHomework.Infraestructure.Identity
{
	public static class ServiceRegistration
	{
		public static void AddIdentityInfraestructureLayer(this IServiceCollection services, IConfiguration config)
		{

			services.AddDbContext<IdentityContext>(opti => opti.UseSqlServer(config.GetConnectionString("IdentityConnection"),
            m => m.MigrationsAssembly("SecondHomework.Infraestructure.Identity")));


			services.AddIdentity<AplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

			services.AddAuthentication();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "";
			});
			services.AddTransient<IAccountService, AccountService>();

            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options =>
			{
				// in producttion true
				options.RequireHttpsMetadata = false;
				options.SaveToken = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer = config["JwtSettings:Issuer"],
					ValidAudience = config["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"])),
					RoleClaimType = "Roles"
				};

				options.Events = new JwtBearerEvents()
				{
					OnAuthenticationFailed = c =>
					{
						c.NoResult();
						c.Response.StatusCode = 500;
						c.Response.ContentType = "text/plain";
						return c.Response.WriteAsync(c.Exception.ToString());

					},

					OnChallenge = c =>
					{
						c.HandleResponse();
						c.Response.StatusCode = 401;
						c.Response.ContentType = "application/json";
						var result = JsonConvert.SerializeObject(new JsonResponse()
						{
							HasError = true,
							ErrorMessage = " You are not Authorizaed"
						});
						return c.Response.WriteAsync(result);

					},
					OnForbidden = c =>
					{
						c.Response.StatusCode = 403;
						c.Response.ContentType = "application/json";
						var result = JsonConvert.SerializeObject(new JsonResponse()
						{
							HasError = true,
							ErrorMessage = " You are not authorized to access this resource"
						});

						return c.Response.WriteAsync(result);
					}


				};
			});

			

		}
	}
}
