using System.Collections.Generic;
using System.Linq;

namespace WebApplicationDemo
{
    public class DatabaseSeeder
    {
        private Context _context { get; set; }
        
        public DatabaseSeeder(Context context) => (_context) = (context);

        public void Seed()
        {
            var booksList = new List<Book>
            {
                new Book{Name="Kapital"},
                new Book{Name="Communist Manifesto"}
            };
            foreach (var book in booksList)
            {
                if (!CheckIfExists(book.Name))
                    _context.Books.Add(book);
            }
            _context.SaveChanges();
        }

        public bool CheckIfExists(string name) => _context.Books.FirstOrDefault(b => b.Name == name) != null;
    }
    
}