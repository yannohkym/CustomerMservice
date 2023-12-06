using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductWebApi.Models;

namespace ProductWebApi
{
	public class ProductDbContext :DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions):base(dbContextOptions)
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
		public DbSet<Product> products { get; set; }
	}
}
