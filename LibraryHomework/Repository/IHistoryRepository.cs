using System.Collections.Generic;
using LibraryStore.Domain.Entities;

namespace LibraryHomework.Repository
{
    public interface IHistoryRepository
    {
        History Add(History history);
        IEnumerable<History> GetAll();
        History GetById(int id);
        bool SaveChanges();
        History UpdateReturnedDay(int id);
    }
}