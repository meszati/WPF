using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;
using XY57LW_HFT_2021221.Repository;

namespace XY57LW_HFT_2021221.Logic
{
    public class MeasurementLogic : IMeasurementLogic
    {
        IMeasurementRepository measurementRepo;

        public MeasurementLogic(IMeasurementRepository measurementRepo)
        {
            this.measurementRepo = measurementRepo;
        }

        public void Create(Measurement measurement)
        {
            if (measurement.Pushup < 0)
            {
                throw new ArgumentException("Negative pushup is not allowed!");
            }

            measurementRepo.Create(measurement);
        }

        public void Delete(int id)
        {
            measurementRepo.Delete(id);
        }

        public Measurement Read(int id)
        {
            return measurementRepo.Read(id);
        }

        public IEnumerable<Measurement> ReadAll()
        {
            return measurementRepo.ReadAll();
        }

        public void Update(Measurement measurement)
        {
            measurementRepo.Update(measurement);
        }

        //iskolánként hány diák csinált10 fekvőnél többet
        public IEnumerable<KeyValuePair<string, int>> StudentsOver10PushUps()
        {
            return from x in measurementRepo.ReadAll().Where(t => t.Pushup > 10)
                   group x by x.Student.Sch.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }

        //iskolánként áltag fekvő szám
        public IEnumerable<KeyValuePair<string, double>> AVGPushUpBySchools()
        {
            return from x in measurementRepo.ReadAll()
                   group x by x.Student.Sch.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Pushup));
        }

        //legtöbb felülést csináló diák
        public IEnumerable<KeyValuePair<string, int>> MostSitUps()
        {
            return from x in measurementRepo.ReadAll()
                   group x by x.Student.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Max(t => t.Situp));
        }

        //legkövérebb diák
        public IEnumerable<KeyValuePair<string, double>> BiggestBMI()
        {
            return from x in measurementRepo.ReadAll()
                   group x by x.Student.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Max(t => t.BMI));
        }

        //legkisebb testzsirral rendelkező diák
        public IEnumerable<KeyValuePair<string, double>> LeastBodyfat()
        {
            return from x in measurementRepo.ReadAll()
                   group x by x.Student.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Max(t => t.Bodyfat));
        }
    }
}
