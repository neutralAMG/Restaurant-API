using Microsoft.AspNetCore.Builder;

namespace SecondHomework.Api.Extensions
{
	public static class AppExtensions
	{
		public static void UseSwaggerExtention(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant webApi");
			});
		}
	}
}
