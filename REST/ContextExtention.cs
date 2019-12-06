using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace REST
{
    public static class ContextExtention
    {
        public static IQueryable<object> Set (this DbContext _context, Type t)
        {
            return (IQueryable<object>)_context.GetType().GetMethod("Set")?.MakeGenericMethod(t).Invoke(_context, null);
        }
    }
}