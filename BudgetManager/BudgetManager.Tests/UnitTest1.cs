using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary;

namespace UnitTest
{

    [TestClass]
    public class UnitTest
    {
        testClass objt;
        string rvalue;

        [TestCleanup]
        public void testClean()
        {
            objt = null;
            rvalue = String.Empty;
        }

        [TestInitialize]
        public void testInit()
        {
            objt = new testClass();
            rvalue = "done";
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(rvalue, objt.testFun());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(rvalue, objt.testFun());
        }
    }
}