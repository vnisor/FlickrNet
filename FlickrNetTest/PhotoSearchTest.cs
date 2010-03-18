﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using FlickrNet;
namespace FlickrNetTest
{
    /// <summary>
    ///This is a test class for FlickrNet.Flickr and is intended
    ///to contain all FlickrNet.Flickr Unit Tests
    ///</summary>
    [TestClass()]
    public class PhotoSearchTest
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
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        Flickr f = new Flickr();

        [TestInitialize]
        public void TestInitialize()
        {
            Flickr.CacheDisabled = true;
            f.ApiKey = TestData.ApiKey;
        }

        [TestMethod]
        public void TestBasicSearch()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "Test";
            PhotoCollection photos = f.PhotosSearch(o);

            Assert.IsTrue(photos.Total > 0, "Total Photos should be greater than zero.");
            Assert.IsTrue(photos.Pages > 0, "Pages should be greaters than zero.");
            Assert.AreEqual(100, photos.PerPage, "PhotosPerPage should be 100.");
            Assert.AreEqual(1, photos.Page, "Page should be 1.");

            Assert.IsTrue(photos.Count > 0, "Photos.Count should be greater than 0.");
            Assert.AreEqual(photos.PerPage, photos.Count);
        }

        [TestMethod]
        public void TestPerPage()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.PerPage = 10;
            o.Tags = "Test";
            PhotoCollection photos = f.PhotosSearch(o);

            Assert.IsTrue(photos.Total > 0, "TotalPhotos should be greater than 0.");
            Assert.IsTrue(photos.Pages > 0, "TotalPages should be greater than 0.");
            Assert.AreEqual(10, photos.PerPage, "PhotosPerPage should be 10.");
            Assert.AreEqual(1, photos.Page, "PageNumber should be 1.");

            Assert.IsTrue(photos.Count > 0, "PhotoCollection Length should be greater than 0.");
            Assert.AreEqual(photos.PerPage, photos.Count);
        }

        [TestMethod]
        public void TestTags()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.PerPage = 10;
            o.Tags = "Test";
            o.Extras = PhotoSearchExtras.Tags;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.IsTrue(photo.Tags.Count > 0, "Should be some tags");
                Assert.IsTrue(photo.Tags.Contains("test"), "At least one should be 'test'");

            }
            
        }

        [TestMethod]
        public void TestUserId()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.UserId = TestData.TestUserId;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.AreEqual(TestData.TestUserId, photo.UserId);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ApiKeyRequiredException))]
        public void TestNoApiKey()
        {
            f.ApiKey = "";
            f.PhotosSearch(new PhotoSearchOptions());

            Assert.Fail("Shouldn't get here");
        }

        [TestMethod]
        [Ignore()]
        public void TestSortDataTakenAscending()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DateTakenAsc;
            o.Extras = PhotoSearchExtras.DateTaken;

            PhotoCollection p = f.PhotosSearch(o);

            for (int i = 1; i < p.Count; i++)
            {
                Console.WriteLine(p[i].DateTaken);
                Assert.AreNotEqual(default(DateTime), p[i].DateTaken);
                Assert.IsTrue(p[i].DateTaken >= p[i - 1].DateTaken, "Date taken should increase");
            }
        }

        [TestMethod]
        [Ignore()]
        public void TestSortDataTakenDescending()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DateTakenDesc;
            o.Extras = PhotoSearchExtras.DateTaken;

            PhotoCollection p = f.PhotosSearch(o);

            for (int i = 1; i < p.Count; i++)
            {
                Console.WriteLine(p[i].DateTaken);
                Assert.AreNotEqual(default(DateTime), p[i].DateTaken);
                Assert.IsTrue(p[i].DateTaken <= p[i - 1].DateTaken, "Date taken should decrease.");
            }
        }

        [TestMethod]
        [Ignore()]
        public void TestSortDataPostedAscending()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DatePostedAsc;
            o.Extras = PhotoSearchExtras.DateUploaded;

            PhotoCollection p = f.PhotosSearch(o);

            for (int i = 1; i < p.Count; i++)
            {
                Console.WriteLine(p[i].DateAdded);
                Assert.AreNotEqual(default(DateTime), p[i].DateAdded);
                Assert.IsTrue(p[i].DateAdded >= p[i - 1].DateAdded, "Date taken should increase.");
            }
        }

        [TestMethod]
        [Ignore()]
        public void TestSortDataPostedDescending()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DatePostedDesc;
            o.Extras = PhotoSearchExtras.DateUploaded;

            PhotoCollection p = f.PhotosSearch(o);

            for (int i = 1; i < p.Count; i++)
            {
                Console.WriteLine(p[i].DateAdded);
                Assert.AreNotEqual(default(DateTime), p[i].DateAdded);
                Assert.IsTrue(p[i].DateAdded <= p[i - 1].DateAdded, "Date taken should increase.");
            }
        }

        [TestMethod]
        public void TestGetLicenseNotNull()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DatePostedDesc;
            o.Extras = PhotoSearchExtras.License;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.IsNotNull(photo.License);
            }
        }

        [TestMethod]
        public void TestGetLicenseAttributionNoDerivs()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DatePostedDesc;
            o.Licenses.Add(LicenseType.AttributionNoDerivsCC);
            o.Extras = PhotoSearchExtras.License;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.AreEqual(LicenseType.AttributionNoDerivsCC, photo.License);
            }
        }

        [TestMethod]
        public void TestGetLicenseNoKnownCopright()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.SortOrder = PhotoSearchSortOrder.DatePostedDesc;
            o.Licenses.Add(LicenseType.NoKnownCopyrightRestrictions);
            o.Extras = PhotoSearchExtras.License;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.AreEqual(LicenseType.NoKnownCopyrightRestrictions, photo.License);
            }
        }

        [TestMethod]
        public void TestSearchTwice()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "microsoft";
            o.PerPage = 10;

            PhotoCollection photos = f.PhotosSearch(o);

            Assert.AreEqual(10, photos.PerPage, "Per page is not 10");

            o.PerPage = 50;
            photos = f.PhotosSearch(o);
            Assert.AreEqual(50, photos.PerPage, "Per page has not changed?");

            photos = f.PhotosSearch(o);
            Assert.AreEqual(50, photos.PerPage, "Per page has changed!");
        }

        [TestMethod]
        public void TestPage()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Tags = "colorful";
            o.PerPage = 10;
            o.Page = 3;

            PhotoCollection photos = f.PhotosSearch(o);

            Assert.AreEqual(3, photos.Page);
        }

        [TestMethod()]
        public void TestIsCommons()
        {
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.IsCommons = true;
            o.Tags = "newyork";
            o.PerPage = 10;
            o.Extras = PhotoSearchExtras.License;

            PhotoCollection photos = f.PhotosSearch(o);

            foreach (Photo photo in photos)
            {
                Assert.AreEqual(LicenseType.NoKnownCopyrightRestrictions, photo.License);
            }
        }
    }


}
