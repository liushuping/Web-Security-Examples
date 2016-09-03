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
                    Author = "Ken Beck"
                },
                new Book {
                    Name = "Structure and Interpretation of Computer Programs",
                    ISBN = "0262510871",
                    Author = "Harold Abelson"
                },
                new Book {
                    Name = "JavaScript: The Good Parts",
                    ISBN = "Douglas Crockford",
                    Author = "0596517742"
                },
                new Book {
                    Name = "CLR via C# (4th Edition)",
                    ISBN = "0735667454",
                    Author = "Jeffrey Richter"
                },
                new Book {
                    Name = "Purely Functional Data Structures",
                    ISBN = "0521663504",
                    Author = "Chris Okasaki"
                },
                new Book {
                    Name = "Learn You a Haskell for Great Good!",
                    ISBN = "1593272839",
                    Author = "Miran Lipovaca"
                }
            };
        }
    }
}