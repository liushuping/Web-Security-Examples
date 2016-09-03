using BooksOnline.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksOnline.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private IBooksRepository _repository;

        public BooksController(IBooksRepository repository)
        {
            _repository = repository;
        }

        [Authorize(ActiveAuthenticationSchemes = "Basic")]
        public ActionResult Get()
        {
            return Ok(_repository.GetBooks());
        }
    }
}
