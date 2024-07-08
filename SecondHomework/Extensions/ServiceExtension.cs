using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace SecondHomework.Api.Extensions
{
	public static class ServiceExtension
	{
		public static void AddSwaggerExtensiom(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();

				xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Restorant api",
					Description = " This api will be responsable for all data distribution",
					//Contact = new OpenApiContact
					//{
					//	Name = "Alejandro",
					//	Email = "heey",
					//	Url = new Uri("https://www.youtube.com/watch?v=fLLHxZVOjxo")
					//}
				});
				options.DescribeAllParametersInCamelCase();

				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					Description = "Input your Bearer token in this format - Bearer (Your token here)"
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
					 new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer",
						},
						Scheme = "Bearer",
						Name = "Bearer",
						In = ParameterLocation.Header,


					  }, new List<string>()
					}

				});				
				
				
			});
		}

		public static void AddApiVersioningExtensiom(this IServiceCollection services)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1.0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
			});
		}
	}
}
