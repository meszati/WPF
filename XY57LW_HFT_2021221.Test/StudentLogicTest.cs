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
                        Sch = fakeSchool
                    },
                    new Student()
                    {
                        Name = "Álmos Ádám",
                        City = "Halásztelek",
                        Sch = fakeSchool
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

        [TestCase("Gyéresi Norbert", true)]
        [TestCase("Ádám", false)]
        public void CreateStudentTest(string name, bool result)
        {
            if (result)
            {
                Assert.That(() => studentLogic.Create(new Student()
                {
                    Name = name,
                    City = "Budapest"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => studentLogic.Create(new Student()
                {
                    Name = name,
                    City = "Halásztelek"

                }), Throws.Exception);
            }
        }
    }
}
