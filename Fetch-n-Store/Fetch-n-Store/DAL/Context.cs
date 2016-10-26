using Fetch_n_Store.Models;
using System.Data.Entity;

namespace Fetch_n_Store.DAL
{
    public class Context : DbContext
    {
        public virtual DbSet<Response> Responses { get; set; }
    }
}