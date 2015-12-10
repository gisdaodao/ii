using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
   public class Items
    {
        // public List<item> itemlist { get; set; }
        public item[] obj { get; set; }
    }
    public class item
    {
        public string text { get; set; }
        public string des { get; set; }
        public string url { get; set; }
    }
}
