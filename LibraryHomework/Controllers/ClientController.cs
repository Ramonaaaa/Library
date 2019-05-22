using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHomework.Services;
using LibraryStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryHomework.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpGet]    
        public IActionResult Index()
        {
            var clients = service.GetAll();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var client = service.GetById(id);
            return View(client);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client newClient)
        {
            if (ModelState.IsValid)
            {
                service.Add(newClient);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newClient);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Client clientToEdit = service.GetById(id);
            return View(clientToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                service.Update(client);
                service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
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