﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JACProject.Database
{
    public class Post
    {
        public int id { get; set; }
        [DataType(DataType.MultilineText)]
        public string text { get; set; }
        public DateTime timeCreated { get; set; }
        public Account creator { get; set; }
        public bool deleted { get; set; }
        public int security { get; set; }
        public string title { get; set; }
    }
}