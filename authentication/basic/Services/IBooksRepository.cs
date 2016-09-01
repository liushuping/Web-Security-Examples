using System.Collections.Generic;
using BooksOnline.Models;

public interface IBooksRepository
{
    IEnumerable<Book> GetBooks();
}