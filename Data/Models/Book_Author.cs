namespace libreriaa_JAMB.Data.Models
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Books { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
