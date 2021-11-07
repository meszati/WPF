using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Data;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Repository
{
    public class MeasurementRepository
    {
        StudentNetfitDbContext ctx;

        public MeasurementRepository(StudentNetfitDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Measurement measurement)
        {
            ctx.Measurements.Add(measurement);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();

        }

        public Measurement Read(int id)
        {
            return ctx.Measurements.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Measurement> ReadAll()
        {
            return ctx.Measurements;
        }

        public void Update(Measurement measurement)
        {
            var oldmeasurement = Read(measurement.ID);
            oldmeasurement.BMI = measurement.BMI;
            oldmeasurement.Bodyfat = measurement.Bodyfat;
            oldmeasurement.Jump = measurement.Jump;
            oldmeasurement.Situp = measurement.Situp;
            oldmeasurement.Pushup = measurement.Pushup;
            ctx.SaveChanges();
        }
    }
}
