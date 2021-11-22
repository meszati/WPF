using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Logic
{
    public interface IMeasurementLogic
    {
        void Create(Measurement measurement);

        void Delete(int id);

        Measurement Read(int id);

        IEnumerable<Measurement> ReadAll();

        void Update(Measurement measurement);

        IEnumerable<KeyValuePair<string, int>> StudentsOver10PushUps();

        IEnumerable<KeyValuePair<string, double>> AVGPushUpBySchools();

        IEnumerable<KeyValuePair<string, int>> MostSitUps();
    }
}
