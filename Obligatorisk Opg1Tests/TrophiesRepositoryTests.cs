using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_Opg1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opg1.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        [TestMethod()]
        public void AddTrophyTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            Trophy t1 = new Trophy() { Competition = "Fodbold", Year = 2000 };
            trophiesRepository.AddTrophy(t1);

            List<Trophy> trophyList = trophiesRepository.GetTrophies();
            Assert.IsTrue(trophyList.Contains(t1));
        }

        [TestMethod()]
        public void GetTrophiesTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            Trophy t1 = new Trophy() { Competition = "Fodbold", Year = 2000 };
            Trophy t2 = new Trophy() { Competition = "Maraton", Year = 1995 };
            trophiesRepository.AddTrophy(t1);
            trophiesRepository.AddTrophy(t2);
            List<Trophy> trophies = trophiesRepository.GetTrophies();


            Assert.IsTrue(trophies.Count == 2);
        }

        [TestMethod()]
        public void GetTrophyByIdTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            Trophy t1 = new Trophy() { Competition = "Fodbold", Year = 2000 };
            Trophy t2 = new Trophy() { Competition = "Maraton", Year = 1995 };
            trophiesRepository.AddTrophy(t1);
            trophiesRepository.AddTrophy(t2);

            Trophy result = trophiesRepository.GetTrophyById(2);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, t2);
        }

        [TestMethod()]
        public void RemoveTrophyTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            Trophy t1 = new Trophy() { Competition = "Fodbold", Year = 2000 };
            Trophy t2 = new Trophy() { Competition = "Maraton", Year = 1995 };
            trophiesRepository.AddTrophy(t1);
            trophiesRepository.AddTrophy(t2);
            trophiesRepository.RemoveTrophy(2);
            List<Trophy> trophies = trophiesRepository.GetTrophies();


            Assert.IsTrue(trophies.Count == 1);
        }

        [TestMethod()]
        public void UpdateTrophyTest()
        {
            Assert.Fail();
        }
    }
}