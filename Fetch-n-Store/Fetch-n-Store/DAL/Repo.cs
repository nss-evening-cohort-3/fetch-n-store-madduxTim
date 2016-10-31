using Fetch_n_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fetch_n_Store.DAL
{
    public class Repo
    {
        public Context context { get; set; }
        public Repo()
        {
            context = new Context();
        }
        public Repo(Context _context)
        {
            context = _context;
        }
        public List<Response> GetAllResponses()
        {
            return context.Responses.ToList();
        }

        public void AddNewResponse(Response response)
        {
            context.Responses.Add(response);
            context.SaveChanges();
        }
    }
}