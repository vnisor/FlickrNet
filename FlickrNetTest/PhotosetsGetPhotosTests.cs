using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlickrNet;

namespace FlickrNetTest
{
    /// <summary>
    /// Summary description for FlickrPhotoSetGetPhotos
    /// </summary>
    [TestClass]
    public class PhotosetsGetPhotosTests
    {
        Flickr f = new Flickr(TestData.ApiKey);

        public PhotosetsGetPhotosTests()
        {
            Flickr.CacheDisabled = true;
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestBasicGetPhotos()
        {
            PhotosetPhotos set = f.PhotosetsGetPhotos("72157618515066456", PhotoSearchExtras.All, PrivacyFilter.None, 1, 10);

            Console.WriteLine(f.LastResponse);

            Assert.AreEqual(8, set.Total, "NumberOfPhotos should be 8.");
            Assert.AreEqual(8, set.Count, "Should be 8 photos returned.");
        }

        [TestMethod]
        public void TestMachineTags()
        {
            PhotosetPhotos set = f.PhotosetsGetPhotos("72157594218885767", PhotoSearchExtras.MachineTags, PrivacyFilter.None, 1, 10);

            bool machineTagsFound = false;

            foreach (Photo p in set)
            {
                if (!String.IsNullOrEmpty(p.MachineTags))
                {
                    machineTagsFound = true;
                    break;
                }
            }

            Assert.IsTrue(machineTagsFound, "No machine tags were found in the photoset");
        }

        [TestMethod]
        public void TestPhotosetFilterMedia()
        {
            // http://www.flickr.com/photos/sgoralnick/sets/72157600283870192/
            // Set contains videos and photos
            PhotosetPhotos theset = f.PhotosetsGetPhotos("72157600283870192", PhotoSearchExtras.Media, PrivacyFilter.None, 1, 100, MediaType.Videos);

            foreach (Photo p in theset)
            {
                Assert.AreEqual("video", p.Media, "Should be video.");
            }

            PhotosetPhotos theset2 = f.PhotosetsGetPhotos("72157600283870192", PhotoSearchExtras.Media, PrivacyFilter.None, 1, 100, MediaType.Photos);
            foreach (Photo p in theset2)
            {
                Assert.AreEqual("photo", p.Media, "Should be photo.");
            }

        }

        [TestMethod]
        public void TestPhotosetGetPhotosWebUrl()
        {
            PhotosetPhotos theset = f.PhotosetsGetPhotos("72157618515066456");

            foreach(Photo p in theset)
            {
                Assert.IsNotNull(p.UserId, "UserId should not be null.");
                Assert.AreNotEqual(String.Empty, p.UserId, "UserId should not be an empty string.");
                string url = "http://www.flickr.com/photos/" + p.UserId + "/" + p.PhotoId + "/";
                Assert.AreEqual(url, p.WebUrl);
            }
        }
    }
}
