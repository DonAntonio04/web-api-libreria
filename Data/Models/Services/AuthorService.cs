﻿using libreriaa_JAMB.Data.ViewModels;
using System;
using System.Linq;

namespace libreriaa_JAMB.Data.Models.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.Fullname
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                Fullname = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Books.Titulo).ToList()
            }).FirstOrDefault();
            return _author;


        }
    }
}
