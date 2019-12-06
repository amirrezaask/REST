using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST
{
    public class BaseRest<TEntity, TContext>: ControllerBase 
    where TContext: DbContext
    where TEntity: class
    {
        private TContext _context ;

        public BaseRest(TContext context) => (_context) = (context);
        
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {

            return await _context.Set(typeof(TEntity)).ToListAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

    }
}