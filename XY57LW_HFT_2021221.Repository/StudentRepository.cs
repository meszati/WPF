using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY57LW_HFT_2021221.Data;
using XY57LW_HFT_2021221.Models;

namespace XY57LW_HFT_2021221.Repository
{
    public class StudentRepository : IStudentRepository
    {
        StudentNetfitDbContext ctx;

        public StudentRepository(StudentNetfitDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Student student)
        {

            ctx.Students.Add(student);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();

        }

        public Student Read(int id)
        {
            return ctx.Students.FirstOrDefault(x => x.StudentID == id);
        }

        public IQueryable<Student> ReadAll()
        {
            return ctx.Students;
        }

        public void Update(Student student)
        {
            var oldstudent = Read(student.StudentID);
            oldstudent.BirthDate = student.BirthDate;
            oldstudent.City = student.City;
            oldstudent.Name = student.Name;
            oldstudent.MothersName = student.MothersName;
            oldstudent.NetfitID = student.NetfitID;
            oldstudent.SchoolID = student.SchoolID;
            ctx.SaveChanges();
        }
    }
}
