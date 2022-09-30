using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestingTemplate.Helpers
{
    public static class Resources
    {
        // Book
        public static string GetBookById = "Book";

        public static string BookCategory = "BookCategory";
        
        public static string GetAllBooks = "Book/GetAll";
        
        public const string GetBooksByCategory = "BookCategory/{0}/Books";
        public static string GetBooksByCat(string categoryId) => string.Format(GetBooksByCategory, categoryId) ;

        public static string AddBook = "Book/Add";

        public static string AddBookCategory = "BookCategory/Add";
        
        public static string UpdateBook = "Book/Update";

        public static string DeleteBook = "Book/";
    }
}
