using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST;

namespace WebApplicationDemo
{
    
    
    public class BaseRest<TEntity, TContext>: ControllerBase where TContext: DbContext
    {
        private TContext _context ;

        public BaseRest(TContext context) => (_context) = (context);
        
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {

            return await _context.Set(typeof(TEntity)).ToListAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<TEntity> Put([FromBody] TEntity entity)
        {
            _context.Set(typeof(TEntity)).Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        

        [HttpDelete]
        public async Task Delete(string name)
        {
            _context.Set(typeof(TEntity)).Remove(new Book {Name = name});
            await _context.SaveChangesAsync();
        }
    }
}