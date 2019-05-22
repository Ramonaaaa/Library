using System.Collections.Generic;
using LibraryStore.Domain.Entities;

namespace LibraryHomework.Services
{
    public interface IClientService
    {
        Client Add(Client client);
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        Client Remove(int id);
        bool SaveChanges();
        Client Update(Client client);
    }
}