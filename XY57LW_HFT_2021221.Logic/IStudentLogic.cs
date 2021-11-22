using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Logic
{
    public interface IStudentLogic
    {
        void Create(Student student);

        void Delete(int id);

        Student Read(int id);

        IEnumerable<Student> ReadAll();

        void Update(Student student);
    }
}
