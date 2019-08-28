using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JACProject.Database
{
    public class Thread
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<Post> content { get; set; }
    }
}