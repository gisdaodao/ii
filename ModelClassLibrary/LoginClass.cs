using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class LoginClass
    {
    }
    [DataContract]
    public class LoginReturnUser
    {
        //            {
        //    "username": "cooldude6",
        //    "phone": "415-392-0202",
        //    "createdAt": "2011-11-07 20:58:34",
        //    "updatedAt": "2011-11-07 20:58:34",
        //    "objectId": "Kc3M222J",
        //    "sessionToken": "pnktnjyb996sj4p156gjtp4im"
        //}
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string createdAt { get; set; }
        [DataMember]
        public string updatedAt { get; set; }
        [DataMember]
        public string objectId { get; set; }
        [DataMember]
        public string sessionToken { get; set; }
    }

    public class Rootobject
    {
        public string createdAt { get; set; }
        public string objectId { get; set; }
        public string sessionToken { get; set; }
    }

}
