using LibraryHomework.Repository;
using LibraryStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHomework.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository repository;
        private readonly IBookRepository bookRepository;
        private readonly IClientRepository clientRepository;

        public HistoryService(IHistoryRepository repository, IBookRepository bookRepository, IClientRepository clientRepository)
        {
            this.repository = repository;
            this.bookRepository = bookRepository;
            this.clientRepository = clientRepository;
        }

        public History Add(int clientId, int bookId)
        {
            //daca clientul si cartea exista si cartea nu este data => adaugam un istoric cu datele furnizate si putem sa ii dam cartea clientului
            var client = clientRepository.GetById(clientId);
            var book = bookRepository.GetById(bookId);
            if(client == null || book == null)
            {
                return null;
            }
            if(!client.IsDeleted && !book.IsDeleted && book.IsAvailable)
            {
                var history = new History()
                {
                    ClientId = client.Id,
                    BookId = book.Id,
                    BorrowedDay = DateTime.Now
                };

                book.IsAvailable = false;
                bookRepository.Update(book);
                return repository.Add(history);
            }
            return null;
        }


        public IEnumerable<History> GetAll()
        {
            return repository.GetAll();
        }

        public History GetById(int id)
        {
            return repository.GetById(id);
        }

        public History UpdateReturnedBook(int id)
        {
            var history = repository.GetById(id);
            history.Book.IsAvailable = true;
            bookRepository.Update(history.Book);
            return repository.UpdateReturnedDay(id);
        }

        public bool SaveChanges()
        {
            return repository.SaveChanges();
        }
    }
}
