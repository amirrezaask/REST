using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationDemo.Controllers
{
    public class Controller: ControllerBase
    {
        private Context _context ;

        public Controller(Context context) => (_context) = (context);
        
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<Book> Put([FromBody] Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
        

        [HttpDelete]
        public async Task Delete(string name)
        {
            _context.Books.Remove(new Book {Name = name});
            await _context.SaveChangesAsync();
        }
    }
}