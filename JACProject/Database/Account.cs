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
    }
}