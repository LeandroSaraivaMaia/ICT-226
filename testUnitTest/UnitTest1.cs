using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testLibrairie;

namespace testUnitTest
{
    [TestClass]
    public class testCalculator
    {
        [TestMethod]
        public void testCalcul()
        {
            testLibrairie.Calculator testCalculatoz = new testLibrairie.Calculator();

            float resExpected = 4;
            float resActual = 0;

            resActual = testCalculatoz.calcul(2, 2, '*');

            Assert.AreEqual(resExpected, resActual);
        }
    }
}
