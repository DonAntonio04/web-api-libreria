using libreriaa_JAMB.Data.ViewModels;
using libreriaa_JAMB.Excepciones;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace libreriaa_JAMB.Data.Models.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher AddPublisher(PublisherVM publisher)
          
        {
            if (StringsStartsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con número", publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);   



        public PublisheWithBooksAndAuthorsVM GetPublisheData(int punblisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == punblisherId)
                .Select(N => new PublisheWithBooksAndAuthorsVM()
                {
                    Name = N.Name,
                    BookAuthors = N.Books.Select(n => new BookAuthorVM()
                    {
                         BookName = n.Titulo,
                         BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList(),
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
           var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if( _publisher != null )
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con el Id {id} no existe");
            }
        }
        private bool StringsStartsWithNumber(string name) => (Regex.IsMatch(name,@"^\d"));
      
    }
}
