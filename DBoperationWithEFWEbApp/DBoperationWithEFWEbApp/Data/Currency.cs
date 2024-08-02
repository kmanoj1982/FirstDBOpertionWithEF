namespace DBoperationWithEFWEbApp.Data
{
	public class Currency
	{
		public int id { get; set; }
		public string? Title { get; set; }
		public string? Descreption { get; set; }
		public bool Isactive { get; set; } = true;
		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime LastUpdated { get; set; } = DateTime.Now;
		public ICollection<Currency> currencies { get; set; }
	}
}
