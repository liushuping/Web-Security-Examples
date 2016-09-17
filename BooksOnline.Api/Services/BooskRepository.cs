using System.Collections.Generic;
using BooksOnline.Models;

namespace BooksOnline.Services
{
    public class BooksRepository : IBooksRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new[] {
                new Book {
                    Name = "Implementation Pattern",
                    ISBN = "0321413091",
                    Author = "Ken Beck",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/51KFODYFA0L._SX381_BO1,204,203,200_.jpg"
                },
                new Book {
                    Name = "Structure and Interpretation of Computer Programs",
                    ISBN = "0262510871",
                    Author = "Harold Abelson",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/51H17R%2BbW8L._SX331_BO1,204,203,200_.jpg"
                },
                new Book {
                    Name = "JavaScript: The Good Parts",
                    ISBN = "Douglas Crockford",
                    Author = "0596517742",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/5166ztxOm9L._SX381_BO1,204,203,200_.jpg"
                },
                new Book {
                    Name = "CLR via C# (4th Edition)",
                    ISBN = "0735667454",
                    Author = "Jeffrey Richter",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/41zZ5aN3ypL._SX408_BO1,204,203,200_.jpg"
                },
                new Book {
                    Name = "Purely Functional Data Structures",
                    ISBN = "0521663504",
                    Author = "Chris Okasaki",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/41XlPaC%2BZqL._SX326_BO1,204,203,200_.jpg"
                },
                new Book {
                    Name = "Learn You a Haskell for Great Good!",
                    ISBN = "1593272839",
                    Author = "Miran Lipovaca",
                    Url = "https://images-na.ssl-images-amazon.com/images/I/41lWWRzqFpL._SX376_BO1,204,203,200_.jpg"
                }
            };
        }
    }
}