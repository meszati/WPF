using NUnit.Framework;
using Moq;
using XY57LW_HFT_2021221.Models;
using XY57LW_HFT_2021221.Repository;
using XY57LW_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY57LW_HFT_2021221.Test
{
    [TestFixture]
    public class SchoolLogicTest
    {
        SchoolLogic schoolLogic;

        public SchoolLogicTest()
        {
            Mock<ISchoolRepository> mockSchoolRepository = new Mock<ISchoolRepository>();

            mockSchoolRepository.Setup((t) => t.Create(It.IsAny<School>()));
            mockSchoolRepository.Setup((t) => t.ReadAll()).Returns(
                new List<School>()
                {
                    new School()
                    {
                        Name = "Terézvárosi",
                        Headmaster = "Gyéresi Norbert"
                    },
                    new School()
                    {
                        Name = "Bocskai",
                        Headmaster = "Galambos Gábor"
                    }
                }.AsQueryable());

            schoolLogic = new SchoolLogic(mockSchoolRepository.Object);
        }

        [TestCase("Terézvárosi", true)]
        [TestCase(null, false)]
        public void CreateSchoolTest(string schoolName, bool result)
        {
            if (result)
            {
                Assert.That(() => schoolLogic.Create(new School()
                {
                    Name = schoolName,
                    Headmaster = "Gyéresi Norbert"
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => schoolLogic.Create(new School()
                {
                    Name = schoolName,
                    Headmaster = "Gyéresi Csaba"
                }), Throws.Exception);
            }
        }
    }
}
