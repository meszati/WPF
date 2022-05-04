using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Endpoint.Services;
using XY57LW_HFT_2021221.Logic;
using XY57LW_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY57LW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentLogic stl;
        IHubContext<SignalRHub> hub;

        public StudentController(IStudentLogic stl, IHubContext<SignalRHub> hub)
        {
            this.stl = stl;
            this.hub = hub;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return stl.ReadAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return stl.Read(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            stl.Create(value);
            hub.Clients.All.SendAsync("StudentCreated", value);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            stl.Update(value);
            hub.Clients.All.SendAsync("StudentUpdated", value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var StudentToDelete = stl.Read(id);
            stl.Delete(id);
            hub.Clients.All.SendAsync("StudentDeleted", StudentToDelete);
        }
    }
}
