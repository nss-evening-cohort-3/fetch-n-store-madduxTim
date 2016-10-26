using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fetch_n_Store.Models
{
    public class Response
    {
        [Key]
        public int ResponseID { get; set; }
        [Required]
        public int StatusCode { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string HTTP_Method { get; set; }
        [Required]
        public int ResponseTime { get; set; }
    }
}