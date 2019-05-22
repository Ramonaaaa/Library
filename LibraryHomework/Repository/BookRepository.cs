using LibraryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext context;

        public BookRepository(LibraryContext context)
        {
            this.context = context;
        }

        public Book Add(Book book)
        {
            book.IsAvailable = true;
            return context.Add(book).Entity;
        }

        public IEnumerable<Book> GetAll(bool? isAvailable)
        {
            if(isAvailable == null)
            {
                return context.Books.Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                return context.Books.Where(x => x.IsAvailable == isAvailable && x.IsDeleted == false).ToList();
            }
  
        }

        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

      
        public Book Remove(int id)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == id);

            if(book != null)
            {
                book.IsDeleted = true;
            }
            return book;
        }

        public Book Update(Book book)
        {
            return context.Books.Update(book).Entity;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }

}

