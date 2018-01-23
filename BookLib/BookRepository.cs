using System;
using System.Collections.Generic;
using System.Text;

namespace My.BookLib
{
    public class BookRepository
    {
        private static List<Book> _bookList = new List<Book>();
        private static int _nextId = 0;

        public List<Book> GetList()
        {
            return _bookList;
        }

        public Book GetBookById(int id)
        {
            return _bookList.Find(c => c.Id == id);
        }

        public void AddBook(Book newBook)
        {
            newBook.Id = _nextId++;
            _bookList.Add(newBook);
        }
        public void EditBook(Book editBook)
        {
            Book originBook = GetBookById(editBook.Id);
            originBook.Title = editBook.Title;
            originBook.Author = editBook.Author;
        }

        public void DeleteBook(int id)
        {
            Book delBook = GetBookById(id);
            _bookList.Remove(delBook);
        }
    }
}
