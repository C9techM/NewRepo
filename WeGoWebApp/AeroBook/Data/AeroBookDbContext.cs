using AeroBook.Models.Account;
using Microsoft.EntityFrameworkCore;
using AeroBook.Models.Flights;

namespace AeroBook.Data
{
	public class AeroBookDbContext: DbContext
	{
		public AeroBookDbContext(DbContextOptions options) : base(options) { }
		public DbSet<User> Users { get; set; }
		public DbSet<AeroBook.Models.Flights.Flightdetails> Flightdetails { get; set; } = default!;
	}
}
