using LibraryHomework.Repository;
using LibraryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository repository;

        public BookService(IBookRepository repository)
        {
            this.repository = repository;
        }

        public Book Add(Book book)
        {
            return repository.Add(book);
        }

        public IEnumerable<Book> GetAll(bool? isAvailable)
        {
            return repository.GetAll(isAvailable);
        }

        public Book GetById(int id)
        {
            return repository.GetById(id);
        }


        public Book Remove(int id)
        {
            return repository.Remove(id);
        }

        public Book Update(Book book)
        {
            return repository.Update(book);
        }

        public bool SaveChanges()
        {
            return repository.SaveChanges();
        }
    }
}
