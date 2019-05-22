using LibraryStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Repository
{
    public class HistoryRepository : IHistoryRepository
    {

        private readonly LibraryContext context;

        public HistoryRepository(LibraryContext context)
        {
            this.context = context;
        }

        public History Add(History history)
        {
            return context.Add(history).Entity;
        }

        public IEnumerable<History> GetAll()
        {
            return context.History.Include(x => x.Book).Include(x => x.Client).ToList();
        }

        public History GetById(int id)
        {
            return context.History.Include(x => x.Book).Include(x => x.Client).FirstOrDefault(x => x.Id == id);
        }
       
        public History UpdateReturnedDay(int id)
        {
            var history = context.History.FirstOrDefault(x => x.Id == id);
            if(history != null && history.ReturnedDay == null)
            {
                history.ReturnedDay = DateTime.Now;
            }
            return history;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }

}

