using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace REST
{
    public static class DbContextExtentions
    {
        public static DbSet<Object> Set(this DbContext _context, Type t)
        {
            return (DbSet<Object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }
    }
}