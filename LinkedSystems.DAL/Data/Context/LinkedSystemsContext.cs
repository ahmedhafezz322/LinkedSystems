using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LinkedSystems.DAL.Data.Models;

namespace LinkedSystems.DAL;

public class LinkedSystemsContext : IdentityDbContext<User>
{
	public LinkedSystemsContext(DbContextOptions<LinkedSystemsContext> options) : base(options)
	{

	}
	public DbSet<Product> Products { get; set; }
}
