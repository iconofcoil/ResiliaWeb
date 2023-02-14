using System;
using ResiliaWeb.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResiliaWeb.Helpers
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options):base(options)
		{
		}

        public DbSet<Notification>? Notifications { get; set; }
    }
}

