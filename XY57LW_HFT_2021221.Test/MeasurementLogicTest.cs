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
    public class MeasurementLogicTest
    {
        MeasurementLogic measurementLogic;

        public MeasurementLogicTest()
        {
            Mock<IMeasurementRepository> mockMeasurementRepository = new Mock<IMeasurementRepository>();

            School fakeSchool = new School()
            {
                Name = "Terézvárosi",
                Headmaster = "Gyéresi Norbert"
            };

            Student fakeStudent = new Student()
            {
                Name = "Ádám Ádám",
                City = "Budapest",
                School = fakeSchool
            };

            mockMeasurementRepository.Setup((t) => t.Create(It.IsAny<Measurement>()));
            mockMeasurementRepository.Setup((t) => t.ReadAll()).Returns(
                new List<Measurement>()
                {
                    new Measurement()
                    {
                        Pushup = 30,
                        Situp = 20,
                        Student = fakeStudent

                    },
                    new Measurement()
                    {
                        Pushup = 4,
                        Situp = 5,
                        Student = fakeStudent
                    }
                }.AsQueryable()) ;

            measurementLogic = new MeasurementLogic(mockMeasurementRepository.Object);
        }

        [Test]
        public void StudentsOver10PushUpsTest()
        {
            var result = measurementLogic.StudentsOver10PushUps().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, int>
                ("Terézvárosi", 1)));
        }

        [Test]
        public void AVGPushUpBySchoolsTest()
        {
            var result = measurementLogic.AVGPushUpBySchools().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, int>
                ("Terézvárosi", 17)));
        }

        [Test]
        public void MostSitUpsTest()
        {
            var result = measurementLogic.MostSitUps().ToArray();

            Assert.That(result[0],
                Is.EqualTo(new KeyValuePair<string, int>
                ("Ádám Ádám", 20)));
        }
    }
}
