using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;

namespace Tests.DataAccess
{
    [TestClass]
    public class UnitTestUnits
    {
        [TestMethod]
        public void TestAreaIndoorDisplayName()
        {
            var area = Units.AreaIndoorEnum.SquareFeet.DisplayName();
            Assert.AreEqual("Square Feet", area);

        }

        [TestMethod]
        public void TestAreaIndoorEnumValue()
        {
            Assert.AreEqual(2, (int)Units.AreaIndoorEnum.SquareFeet);
        }

        [TestMethod]
        public void TestAreaIndoorDictionary()
        {
            Assert.AreEqual("Square Feet", Units.AreaIndoor[2]);
        }

    }
}
