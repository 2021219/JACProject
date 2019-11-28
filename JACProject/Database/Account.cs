using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JACProject.Database
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool deleted { get; set; }
        public int security { get; set; }
        public string location { get; set; }
        public string profileImageURL { get; set; }
        public bool showEmail { get; set; }
        public string nickName { get; set; }
        public int postCount { get; set; }
    }
}