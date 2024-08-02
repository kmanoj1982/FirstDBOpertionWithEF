namespace DBoperationWithEFWEbApp.Data
{
	public class Book
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int? NoOfPage { get; set; }
		public string? Author { get; set; }
		public bool? IsActive { get; set; } = true;
		public DateTime? CreatedDate { get; set; }= DateTime.Now;
		public DateTime? ModifiedDate { get; set; }= DateTime.Now;
        public DateTime? ModifiedDateGit { get; set; } = DateTime.Now;
        //public int LanguageId { get; set; }
        //public Language Language { get; set; }
    }
}
