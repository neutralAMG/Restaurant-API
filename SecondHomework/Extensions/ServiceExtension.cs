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

				xmlFiles.ForEach(xmlFile =>  options.IncludeXmlComments(xmlFile));

				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Restorant api",
					Description = " This api will be responsable for all data distribution",
					Contact = new OpenApiContact
					{
						Name = "Alejandro",
						Email = "heey",
						Url = new Uri("")
					}
				});
				options.DescribeAllParametersInCamelCase();
			});
		}

		public static void AddApiVersioningExtensiom(this IServiceCollection services)
		{
			services.AddApiVersioning(options => {
				options.DefaultApiVersion = new ApiVersion(1.0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
			});
		}
	}
}
