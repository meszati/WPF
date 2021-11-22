using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;
using XY57LW_HFT_2021221.Repository;

namespace XY57LW_HFT_2021221.Logic
{
    public class SchoolLogic : ISchoolLogic
    {
        ISchoolRepository schoolRepo;

        public SchoolLogic(ISchoolRepository schoolRepo)
        {
            this.schoolRepo = schoolRepo;
        }

        public void Create(School school)
        {
            if(school.Name == null)
            {
                throw new ArgumentException("This field cannot be empty!");
            }

            schoolRepo.Create(school);
        }

        public void Delete(int id)
        {
            schoolRepo.Delete(id);
        }

        public School Read(int id)
        {
            return schoolRepo.Read(id);
        }

        public IEnumerable<School> ReadAll()
        {
            return schoolRepo.ReadAll();
        }

        public void Update(School school)
        {
            schoolRepo.Update(school);
        }
    }
}
