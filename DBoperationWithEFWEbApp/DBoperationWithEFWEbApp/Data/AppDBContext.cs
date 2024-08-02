using Microsoft.EntityFrameworkCore;

namespace DBoperationWithEFWEbApp.Data
{
	public class AppDBContext:DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
		{ 
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Currency>().HasData(
			new Currency() { id = 1, Title = "INR", Descreption = "Indian INR" },
			new Currency() { id = 2, Title = "Dollar", Descreption = "Dollar" },
			new Currency() { id = 3, Title = "Euro", Descreption = "Euro" },
			new Currency() { id = 4, Title = "Diner", Descreption = "Diner" }

			);

			modelBuilder.Entity<Language>().HasData(
				 new Language() {ID=1,Title="Hindi", Description="Hindi"}
				,new Language() {ID=2,Title="English", Description="English"}
				,new Language() {ID=3,Title="Urdu", Description="Urdu"}
				,new Language() {ID=4,Title="Panjabi", Description="Panjabhi"}
				);
		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<BookPrice> BookPrices { get; set; }
		
	}
}
