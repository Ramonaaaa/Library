using LibraryHomework.Repository;
using LibraryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;

        public ClientService(IClientRepository repository)
        {
            this.repository = repository;
        }

        public Client Add(Client client)
        {
            return repository.Add(client);
        }

        public IEnumerable<Client> GetAll()
        {
            return repository.GetAll();
        }

        public Client GetById(int id)
        {
            return repository.GetById(id);
        }
       
        public Client Remove(int id)
        {
            return repository.Remove(id);
        }

        public Client Update(Client client)
        {
            return repository.Update(client);
        }

        public bool SaveChanges()
        {
            return repository.SaveChanges();
        }
    }
}
