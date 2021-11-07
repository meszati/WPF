using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Data;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        StudentNetfitDbContext ctx;

        public SchoolRepository(StudentNetfitDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(School school)
        {
            ctx.Schools.Add(school);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();

        }

        public School Read(int id)
        {
            return ctx.Schools.FirstOrDefault(x => x.SchID == id);
        }

        public IQueryable<School> ReadAll()
        {
            return ctx.Schools;
        }

        public void Update(School school)
        {
            var oldschool = Read(school.SchID);
            oldschool.Headmaster = school.Headmaster;
            oldschool.Location = school.Location;
            oldschool.Name = school.Name;
            oldschool.Phone = school.Phone;
            ctx.SaveChanges();
        }
    }
}
