using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Repository
{
    interface IMeasurementRepository
    {
        void Create(Measurement measurement);

        void Delete(int id);

        Measurement Read(int id);

        IQueryable<Measurement> ReadAll();

        void Update(Measurement measurement);
    }
}
