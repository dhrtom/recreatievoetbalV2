using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<RSSFeed>> Get()
        {
            return new RSSFeed[] {new RSSFeed
            {
                Description = "Desc 1",
                Link = "https://d1.com",
                Title = "D1"
            }, new RSSFeed
            {
                Description = "Desc 2",
                Link = "https://d2.com",
                Title = "D2"
            }, new RSSFeed
            {
                Description = "Desc 3",
                Link = "https://d3.com",
                Title = "D3"
            }};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}