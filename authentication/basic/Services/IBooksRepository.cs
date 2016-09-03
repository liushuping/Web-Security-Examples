using System.Collections.Generic;
using BooksOnline.Models;

namespace BooksOnline.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
    }
}