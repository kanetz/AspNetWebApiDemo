using System.Collections.Generic;
using System.Web.Http;
using AspNetWebApiDemo.Models;

namespace AspNetWebApiDemo.Controllers
{
    public class CoursesController : ApiController
    {
        // GET api/values
        public IEnumerable<Course> Get()
        {
            return Course.All();
        }
    }
}