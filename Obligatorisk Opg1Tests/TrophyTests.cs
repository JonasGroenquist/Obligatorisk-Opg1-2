using Obligatorisk_Opg1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opg1.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            Trophy t1 = new Trophy() { ID = 1, Competition = "100m Sprint", Year = 1970 };
            t1.ValidateAll();

            Trophy t2 = new Trophy() { ID = 2, Competition = "100m Sprint", Year = 2025 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => t2.ValidateAll());

            Trophy t3= new Trophy() { ID = 3, Competition = "100m Sprint", Year = 1969 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => t3.ValidateAll());

            Trophy t4 = new Trophy() { ID = 4, Competition = "OL", Year = 2000 };
            Assert.ThrowsException<ArgumentException>(() => t4.ValidateAll());

            Trophy t5 = new Trophy() { ID = 5, Competition = "Fodbold", Year = null };
            Assert.ThrowsException<ArgumentNullException>(() => t5.ValidateAll());
            Trophy t6 = new Trophy() { ID = 5, Competition = null, Year = 2000 };
            Assert.ThrowsException<ArgumentNullException>(() => t6.ValidateAll());
        }
    }
}