using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.BookLib;

namespace BookManager.Controllers
{
    public class BookManagerController : Controller
    {
        private readonly BookRepository _bookRepo = new BookRepository();
        // GET: BookManager
        public ActionResult Index()
        {
            return View(_bookRepo.GetList());
        }

        // GET: BookManager/Details/5
        public ActionResult Details(int id)
        {

            return View(_bookRepo.GetBookById(id));
        }

        // GET: BookManager/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: BookManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book newBook, IFormCollection collection)
        {
            try
            {
                _bookRepo.AddBook(newBook);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookRepo.GetBookById(id));
        }

        // POST: BookManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book editedBook, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _bookRepo.EditBook(editedBook);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bookRepo.GetBookById(id));
        }

        // POST: BookManager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                _bookRepo.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}