using Fetch_n_Store.DAL;
using Fetch_n_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fetch_n_Store.Controllers
{
    public class ResponseController : ApiController
    {
        Repo repo = new Repo();
        // GET api/<controller>
        // obviously this is now how you display all the responses in table UI. 
        public List<Response> Get()
        {
            return repo.GetAllResponses();
        }

        // POST api/<controller>
        public dynamic Post([FromBody]dynamic data)
        {
            Response _response = new Response { StatusCode = data.StatusCode, URL = data.URL, HTTP_Method = data.HTTP_Method, ResponseTime = data.ResponseTime };
            repo.AddNewResponse(_response);
            return _response;
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}