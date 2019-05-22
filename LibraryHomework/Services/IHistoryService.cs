using System.Collections.Generic;
using LibraryStore.Domain.Entities;

namespace LibraryHomework.Services
{
    public interface IHistoryService
    {
        History Add(int clientId, int bookId);
        IEnumerable<History> GetAll();
        History GetById(int id);
        bool SaveChanges();
        History UpdateReturnedBook(int id);
    }
}