﻿using System.Collections.Generic;

namespace libreriaa_JAMB.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }

    }

    public class PublisheWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }
    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
