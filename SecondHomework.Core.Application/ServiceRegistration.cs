

using Microsoft.Extensions.DependencyInjection;

namespace SecondHomework.Core.Application
{
	public static class ServiceRegistration
	{
		public static void AddAplicationService(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}
	}
}
