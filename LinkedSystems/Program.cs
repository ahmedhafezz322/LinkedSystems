using AutoMapper;
using LinkedSystems.BL;
using LinkedSystems.DAL;
using LinkedSystems.DAL.Data.Models;
using LinkedSystems.DAL.Repositories.Products_Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Context
var connectionString = builder.Configuration.GetConnectionString("linkedDb");
builder.Services.AddDbContext<LinkedSystemsContext>(options => options.UseSqlServer(connectionString));
#endregion

#region ASP Identity

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 5;

	options.User.RequireUniqueEmail = true;

	options.Lockout.MaxFailedAccessAttempts = 3;
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
})
			.AddEntityFrameworkStores<LinkedSystemsContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = "default";
	options.DefaultChallengeScheme = "default";
}).
	AddJwtBearer("default", options =>
	{
		var secretKey = builder.Configuration.GetValue<string>("SecretKey");
		var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
		var key = new SymmetricSecurityKey(secretKeyInBytes);

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			IssuerSigningKey = key
		};
	});
#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AllowAdminAndManager", policy =>
		policy
		.RequireClaim(ClaimTypes.Role, "Administrator", "Manager"));
});


#endregion

#region DPI
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<IProductsManager, ProductsManager>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
