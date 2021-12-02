using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY57LW_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStudentLogic sl;
        IMeasurementLogic ml;

        public StatController(IStudentLogic sl, IMeasurementLogic ml)
        {
            this.sl = sl;
            this.ml = ml;
        }
        
        public IEnumerable<KeyValuePair<string, int>> StudentsCountBySchool()
        {
            return sl.StudentsCountBySchool();
        }

        public IEnumerable<KeyValuePair<string, int>> StudentsOver10PushUps()
        {
            return ml.StudentsOver10PushUps();
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPushUpBySchools()
        {
            return ml.AVGPushUpBySchools();
        }

        public IEnumerable<KeyValuePair<string, int>> MostSitUps()
        {
            return ml.MostSitUps();
        }

        public IEnumerable<KeyValuePair<string, double>> BiggestBMI()
        {
            return ml.BiggestBMI();
        }

        public IEnumerable<KeyValuePair<string, double>> LeastBodyfat()
        {
            return ml.LeastBodyfat();
        }
    }
}
