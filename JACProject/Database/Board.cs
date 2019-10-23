using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JACProject.Database
{
    public class Board
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Board> subBoards { get; set; }
        public List<Thread> threads { get; set; }
        public bool deleted { get; set; }
        public int order { get; set; }
        public int security { get; set; }
        public bool initial { get; set; }
        public string section { get; set; }
    }
}