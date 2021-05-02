using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}

		public DbSet<Folder> Folders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Folder>()
				.Property(c => c.FolderType).HasConversion<int>();

			modelBuilder.Entity<Folder>().HasOne(x => x.Parent).WithMany(x => x.Children)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
