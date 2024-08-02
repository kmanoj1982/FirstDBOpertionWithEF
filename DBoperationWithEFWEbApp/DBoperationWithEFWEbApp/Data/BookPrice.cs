namespace DBoperationWithEFWEbApp.Data
{
	public class BookPrice
	{
		public int Id { get;set; }
		
		
		public int Amount { get;set; }
		public int BookID { get; set; }
		public Book Book { get; set; }
		public int CurrencyID { get; set; }
		public Currency Currency { get; set; }

		
	}
}
