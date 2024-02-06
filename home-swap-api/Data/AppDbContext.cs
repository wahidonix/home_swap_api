using System;
using home_swap_api.Models;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<House> Houses { get; set; }
		public DbSet<Offer> Offers { get; set; }
		public DbSet<Image> Images { get; set; }
    }
}

