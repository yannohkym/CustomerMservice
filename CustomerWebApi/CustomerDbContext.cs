using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi
{
	public class CustomerDbContext : DbContext
	{
		public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
		{
			try
			{
				var databasecreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
				if (databasecreator != null)
				{
					if (!databasecreator.CanConnect()) databasecreator.Create();
					if (!databasecreator.HasTables()) databasecreator.CreateTables();
				}
			}
			catch (Exception ex)
			{
				
				Console.WriteLine(ex.Message);

			}



		}
		public  DbSet<Customer>  customers { get; set; }
	}
}