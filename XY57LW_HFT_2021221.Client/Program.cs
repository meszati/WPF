using System;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:9712");

            var schools = rest.Get<School>("school");
            var students = rest.Get<Student>("student");
            var measurements = rest.Get<Measurement>("measurement");
        }
    }
}
