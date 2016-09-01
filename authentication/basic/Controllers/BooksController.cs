using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BooksOnline.Models;

namespace BooksOnline.Controllers
{
    public class BooksController : Controller
    {
        private IBooksRepository _repository;

        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<Book> Index()
        {
            return _repository.GetBooks();
        }
    }
}
