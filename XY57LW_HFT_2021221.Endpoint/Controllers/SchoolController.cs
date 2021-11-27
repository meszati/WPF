using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Logic;
using XY57LW_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY57LW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        ISchoolLogic sl;

        public SchoolController(ISchoolLogic sl)
        {
            this.sl = sl;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<School> Get()
        {
            return sl.ReadAll();
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public School Get(int id)
        {
            return sl.Read(id);
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Post([FromBody] School value)
        {
            sl.Create(value);
        }

        // PUT api/<SchoolController>/5
        [HttpPut]
        public void Put([FromBody] School value)
        {
            sl.Update(value);
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }
    }
}
