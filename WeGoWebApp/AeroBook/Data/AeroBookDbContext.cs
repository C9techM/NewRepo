using AeroBook.Models.Flights;
using Microsoft.EntityFrameworkCore;
using AeroBook.Data.Models.Account;

namespace AeroBook.Data
{
    public class AeroBookDbContext: DbContext
	{
		public AeroBookDbContext(DbContextOptions options) : base(options) { }
		public DbSet<User> Users { get; set; }
		public DbSet<Flightdetails> Flightdetails { get; set; }
		public DbSet<BookingDetails> BookingDetails { get; set; }
		public DbSet<PassengerDetails> PassengerDetails { get; set; }
	}
}
