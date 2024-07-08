using Microsoft.AspNetCore.Identity;
using SecondHomework.Api.Extensions;
using SecondHomework.Core.Application;
using SecondHomework.Infraestructure.Identity;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Seeds;
using SecondHomework.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddInfraestructurePersistanceLayer(builder.Configuration);

builder.Services.AddIdentityInfraestructureLayer(builder.Configuration);

builder.Services.AddAplicationLayer();

builder.Services.AddApiVersioningExtensiom();

builder.Services.AddHealthChecks();

builder.Services.AddSwaggerExtensiom();


builder.Services.AddApiVersioningExtensiom();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddApiVersioning(setup =>
{
	setup.ReportApiVersions = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwaggerExtention();
	
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwaggerExtention();

app.UseHealthChecks("/health");
//app.UseSession();
app.MapControllers();

using(var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var userManager = services.GetRequiredService<UserManager<AplicationUser>>();	
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

		await DefaultRols.SeedAsync(userManager, roleManager);
		await DefaultBasicUser.SeedAsync(userManager, roleManager);
		await SuperAdminUser.SeedAsync(userManager, roleManager);
		await DefaultAdminUser.SeedAsync(userManager, roleManager);
	}catch{

	}
}

app.Run();
