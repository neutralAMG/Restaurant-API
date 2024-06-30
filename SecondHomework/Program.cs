using Microsoft.AspNetCore.Identity;
using SecondHomework.Infraestructure.Identity;
using SecondHomework.Infraestructure.Identity.Entities;
using SecondHomework.Infraestructure.Identity.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityInfraestructureLayer(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

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
