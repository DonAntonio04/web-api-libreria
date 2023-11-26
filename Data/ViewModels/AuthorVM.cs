using System.Collections.Generic;

namespace libreriaa_JAMB.Data.ViewModels
{
    public class AuthorVM
    {
        public string Fullname { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string Fullname { get; set;}
        public List<string> BookTitles { get; set; }
    }
}
