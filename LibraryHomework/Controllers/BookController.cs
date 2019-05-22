using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHomework.Services;
using LibraryStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHomework.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var books = service.GetAll(null);
            return View(books);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = service.GetById(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book newBook)
        {
            if (ModelState.IsValid)
            {
                service.Add(newBook);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newBook);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book bookToEdit = service.GetById(id);
            return View(bookToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                service.Update(book);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var delete = service.GetById(id);
            return View(delete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            service.Remove(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}