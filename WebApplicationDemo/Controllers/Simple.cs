using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Simple : BaseRest<Book, Context>
    {
        public Simple(Context context) : base(context)
        {
        }
    }
}