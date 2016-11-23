using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UraApp.Services.Abstract;
using UraApp.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UraApp.Controllers
{
    [Route("api/[controller]")]
    public class RoleTypeController : Controller
    {

        private IRoleTypeService _service;

        public RoleTypeController(IRoleTypeService service)
        {
            _service = service;
        }
     
        // GET: api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<RoleType> Get()
        {
            return _service.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]RoleType roleType)
        {
            _service.Add(roleType);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
