using System;
using NUnit.Framework;
using Moq;
using XY57LW_HFT_2021221.Models;
using XY57LW_HFT_2021221.Repository;
using XY57LW_HFT_2021221.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY57LW_HFT_2021221.Test
{
    [TestFixture]
    public class StudentLogicTest
    {
        StudentLogic studentLogic;

        public StudentLogicTest()
        {
            Mock<IStudentRepository> mockStudentRepository = new Mock<IStudentRepository>();

            School fakeSchool = new School()
            {
                Name = "Terézvárosi",
                Headmaster = "Gyéresi Norbert"
            };

            mockStudentRepository.Setup((t) => t.Create(It.IsAny<Student>()));
            mockStudentRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Student>()
                {
                    new Student()
                    {
                        Name = "Ádám Ádám",
                        City = "Budapest",
                        School = fakeSchool
                    },
                    new Student()
                    {
                        Name = "Álmos Ádám",
                        City = "Halásztelek",
                        School = fakeSchool
                    }
                }.AsQueryable());

            studentLogic = new StudentLogic(mockStudentRepository.Object);
        }

        [Test]
        public void StudentsCountBySchoolTest()
        {
            var result = studentLogic.StudentsCountBySchool().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, int>
                ("Terézvárosi", 2)));
        }

        [Test]
        public void StudentsBySchoolTest()
        {
            var result = studentLogic.StudentsBySchool().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, IEnumerable<string>>
                ("Terézvárosi", new string[] { "Ádám Ádám", "Álmos Ádám"})));
        }
    }
}
