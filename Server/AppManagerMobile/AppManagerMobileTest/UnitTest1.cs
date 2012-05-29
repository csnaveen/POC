using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileDataService;

namespace AppManagerMobileTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize()
         {
         }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetDeviceData()
        {
            List<ObjectData> devices = new List<ObjectData>{ new ObjectData(){ ObjectID=3, ParentObjectID=1, Name="cpu"}, 
                new ObjectData(){ ObjectID=4, ParentObjectID=3, Name="0"}, new ObjectData(){ ObjectID=5, ParentObjectID=1, Name="memory"},
                new ObjectData(){ ObjectID=6, ParentObjectID=5, Name="vm0"}, new ObjectData(){ ObjectID=7, ParentObjectID=5, Name="vm1"} };

            QDBData datamodel = QDBData.Instance();
            var devicehier = datamodel.GetDeviceData(0, 34);

            int i = 3;

            //var v = from d in devices select new{ name = d.Name, children = ( from sub in devices where sub.ParentObjectID==d.ObjectID select new{ 

        }
    }
}
