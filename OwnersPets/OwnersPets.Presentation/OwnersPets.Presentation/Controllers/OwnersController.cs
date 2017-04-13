using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwnersPets.Presentation.Controllers
{
    public class OwnersController : ApiController
    {
        // GET: api/Owners
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Owners/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Owners
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Owners/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Owners/5
        public void Delete(int id)
        {
        }
    }
}
