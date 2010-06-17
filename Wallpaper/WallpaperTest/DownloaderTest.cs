using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wallpaper;
namespace WallpaperTest
{
    
    
    /// <summary>
    ///This is a test class for DownloaderTest and is intended
    ///to contain all DownloaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DownloaderTest
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
        ///A test for Download
        ///</summary>
        [TestMethod()]
        public void DownloadTest()
        {
            var feed = new WpdbFeed()
            {
                Resolution = "1024x768"
            };
            var path = @"d:\";
            Downloader.Instance.Download(feed, path);
        }

        /// <summary>
        ///A test for DownloadAPage
        ///</summary>
        [TestMethod()]
        public void DownloadAPageTest()
        {
            string resolution = "1024x768";
            string outputFolder = testContextInstance.TestDeploymentDir;
            int page = 1;
            Downloader.Instance.DownloadAPage(resolution, outputFolder, page);
        }

        /// <summary>
        ///A test for DownloadFeed
        ///</summary>
        [TestMethod()]
        public void DownloadFeedTest()
        {
            string resolution = "1024x768";
            string outputFolder = testContextInstance.TestDeploymentDir;
            Downloader.Instance.DownloadFeeds(resolution, outputFolder);
        }
    }
}
