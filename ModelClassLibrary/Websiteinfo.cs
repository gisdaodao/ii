using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Websiteinfo
    {
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public string email { get; set; }
        public List<string> keyword { get; set; }
        public string owneremail { get; set; }
        public string ownnername { get; set; }
        public string begin { get; set; }
        public int count { get; set; }
        public string objectId { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }

    public class Favratesites
    {
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string articleurl { get; set; }
        public string contentname { get; set; }
        public string createdAt { get; set; }
        public string objectId { get; set; }
        public string recordtype { get; set; }
        public string updatedAt { get; set; }
        public string userid { get; set; }
    }

}
