using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fetch_n_Store.DAL;
using Fetch_n_Store.Models;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Fetch_n_Store.Tests.DAL
{
    [TestClass]
    public class RepoTests
    {
        Mock<Context> mock_context { get; set; }
        List<Response> response_list { get; set; }
        Mock<DbSet<Response>> mock_table { get; set; }
        Repo repo { get; set; }

        //Bogus Responses for Tests 
        Response fauxResponse1 = new Response { ResponseID = 1, StatusCode = 500, URL = "www.facebook.com", HTTP_Method = "GET", ResponseTime = 2 };
        Response fauxResponse2 = new Response { ResponseID = 2, StatusCode = 400, URL = "www.bacon.com", HTTP_Method = "HEAD", ResponseTime = 3 };

        public void ConnectMocksToDataStore()
        {
            var queryable_response_list = response_list.AsQueryable();
            mock_table.As<IQueryable<Response>>().Setup(r => r.Provider).Returns(queryable_response_list.Provider);
            mock_table.As<IQueryable<Response>>().Setup(r => r.Expression).Returns(queryable_response_list.Expression);
            mock_table.As<IQueryable<Response>>().Setup(r => r.ElementType).Returns(queryable_response_list.ElementType);
            mock_table.As<IQueryable<Response>>().Setup(r => r.GetEnumerator()).Returns(queryable_response_list.GetEnumerator);
            mock_context.Setup(r => r.Responses).Returns(mock_table.Object);
            mock_table.Setup(r => r.Add(It.IsAny<Response>())).Callback((Response r) => response_list.Add(r));
            mock_table.Setup(r => r.Remove(It.IsAny<Response>())).Callback((Response r) => response_list.Remove(r));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<Context>();
            mock_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new Repo(mock_context.Object);
            ConnectMocksToDataStore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void CanCreateRepoInstance()
        {
            Repo repo = new Repo();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void WorksWithMock()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void RepoHasContext()
        {
            Context actual = repo.context;
            Assert.IsInstanceOfType(actual, typeof(Context));
        }
        [TestMethod]
        public void ResponseDbIsEmpty()
        {
            List<Response> all_responses = repo.GetAllResponses();
            int expected = 0;
            int actual = all_responses.Count();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CanAddResponseToDatabase()
        {
            repo.AddNewResponse(fauxResponse1);
            List<Response> all_responses = repo.GetAllResponses();
            int expected = 1;
            int actual = all_responses.Count();
            Assert.AreEqual(expected, actual);
        }
    }
}
