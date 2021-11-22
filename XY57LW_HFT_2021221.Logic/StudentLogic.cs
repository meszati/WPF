using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Models;
using XY57LW_HFT_2021221.Repository;

namespace XY57LW_HFT_2021221.Logic
{
    class StudentLogic : IStudentLogic
    {
        IStudentRepository studentRepo;

        public StudentLogic(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public void Create(Student student)
        {
            if (student.Name.Length < 5)
            {
                throw new ArgumentException("The name must be atleast 6 character long");
            }

            studentRepo.Create(student);
        }

        public void Delete(int id)
        {
            studentRepo.Delete(id);
        }

        public Student Read(int id)
        {
            return studentRepo.Read(id);
        }

        public IEnumerable<Student> ReadAll()
        {
            return studentRepo.ReadAll();
        }

        public void Update(Student student)
        {
            studentRepo.Update(student);
        }
    }
}
