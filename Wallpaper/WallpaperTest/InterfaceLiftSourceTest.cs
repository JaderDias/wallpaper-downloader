using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallpaper;

namespace WallpaperTest
{
    
    
    /// <summary>
    ///This is a test class for InterfaceLiftSourceTest and is intended
    ///to contain all InterfaceLiftSourceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InterfaceLiftSourceTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetResourceUris
        ///</summary>
        [TestMethod()]
        public void GetResourceUrisTest()
        {
            var target = new InterfaceLiftSource()
                {
                    Resolution = "1024x768"
                };
            int pageNumber = 1;
            var actual = target.GetResourceUris(pageNumber).ToArray();
            Assert.AreEqual(10, actual.Count());
        }

        /// <summary>
        ///A test for GetPageCount
        ///</summary>
        [TestMethod()]
        public void GetPageCountTest()
        {
            var target = new InterfaceLiftSource();
            var expected = 198;
            var actual = target.GetPageCount();
            Assert.IsTrue(actual >= expected);
        }

        /// <summary>
        ///A test for GetPage
        ///</summary>
        [TestMethod()]
        public void GetPageTest()
        {
            var target = new InterfaceLiftSource();
            int pageNumber = 0;
            var actual = target.GetPage(pageNumber);
            Assert.IsTrue(!String.IsNullOrEmpty(actual));
        }
    }
}
