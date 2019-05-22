using LibraryStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Repository
{
    public class ClientRepository : IClientRepository
    {

        private readonly LibraryContext context;

        public ClientRepository(LibraryContext context)
        {
            this.context = context;
        }

        public Client Add(Client client)
        {
            return context.Add(client).Entity;
        }

        public IEnumerable<Client> GetAll()
        {
            return context.Clients.Where(x => x.IsDeleted == false);
        }

        public Client GetById(int id)
        {
            return context.Clients.Include(x => x.HistoryBooks).ThenInclude(hb => hb.Book)
                .FirstOrDefault(x => x.Id == id);
        }


        public Client Remove(int id)
        {
            var client = context.Clients.FirstOrDefault(x => x.Id == id);

            if (client != null)
            {
                client.IsDeleted = true;
            }
            return client;
        }

        public Client Update(Client client)
        {
            return context.Clients.Update(client).Entity;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }

}

