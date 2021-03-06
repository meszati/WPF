using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Repository
{
    public interface IStudentRepository
    {
        void Create(Student student);

        void Delete(int id);

        Student Read(int id);

        IQueryable<Student> ReadAll();

        void Update(Student student);
    }
}
