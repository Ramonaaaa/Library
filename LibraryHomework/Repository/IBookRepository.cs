using System.Collections.Generic;
using LibraryStore.Domain.Entities;

namespace LibraryHomework.Repository
{
    public interface IBookRepository
    {
        Book Add(Book book);
        IEnumerable<Book> GetAll(bool? isAvailable);
        Book GetById(int id);
        Book Remove(int id);
        bool SaveChanges();
        Book Update(Book book);
    }
}