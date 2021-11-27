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
    public class MeasurementController : ControllerBase
    {
        IMeasurementLogic ml;

        public MeasurementController(IMeasurementLogic ml)
        {
            this.ml = ml;
        }

        // GET: api/<MeasurementController>
        [HttpGet]
        public IEnumerable<Measurement> Get()
        {
            return ml.ReadAll();
        }

        // GET api/<MeasurementController>/5
        [HttpGet("{id}")]
        public Measurement Get(int id)
        {
            return ml.Read(id);
        }

        // POST api/<MeasurementController>
        [HttpPost]
        public void Post([FromBody] Measurement value)
        {
            ml.Create(value);
        }

        // PUT api/<MeasurementController>/5
        [HttpPut]
        public void Put([FromBody] Measurement value)
        {
            ml.Update(value);
        }

        // DELETE api/<MeasurementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.Delete(id);
        }
    }
}
