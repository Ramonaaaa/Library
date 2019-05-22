using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHomework.Models;
using LibraryHomework.Services;
using LibraryStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Omu.ValueInjecter;

namespace LibraryHomework.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryService service;

        public HistoryController(IHistoryService service)
        {
            this.service = service;
        }

        private IEnumerable<HistoryViewModel> Transform(IEnumerable<History> historyList)
        {
            var historyViewModelList = new List<HistoryViewModel>();
            foreach (var history in historyList)
            {
                var historyViewModel = new HistoryViewModel();
                historyViewModel.InjectFrom(history);
                historyViewModel.ClientName = history.Client.FirstName + " " + history.Client.SecondName;
                historyViewModel.BookTitle = history.Book.Name;
                historyViewModelList.Add(historyViewModel);
            }
            return historyViewModelList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var historyList = service.GetAll();
            var historyViewModel = Transform(historyList);
            return View(historyViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var history = service.GetById(id);
            return View(history);
        }

        [HttpGet]
        public IActionResult Create([FromServices] IBookService bookService, [FromServices] IClientService clientService)
        {
            var bookList = bookService.GetAll(true);
            var clientList = clientService.GetAll();
            ViewBag.BookList = new SelectList(bookList, "Id", "Name");
            ViewBag.ClientList = new SelectList(clientList, "Id", "FullName");
            return View(new HistoryCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HistoryCreateViewModel newHistory)
        {
            if (ModelState.IsValid)
            {
                service.Add(newHistory.ClientId, newHistory.BookId);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newHistory);
        }

        [HttpGet]
        public IActionResult ReturnBook(int id)
        {
            History historyToEdit = service.GetById(id);
            return View(historyToEdit);
        }

        [HttpPost, ActionName("ReturnBook")]
        [ValidateAntiForgeryToken]
        public IActionResult ReturnBookConfirmation(int id)
        {
            service.UpdateReturnedBook(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}