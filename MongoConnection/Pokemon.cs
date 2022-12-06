using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoConnection
{
    public class Pokemon
    {
        public ObjectId _id { get; set; }
        public string ability { get; set; }
        public string backgroundImage { get; set; }
        public string clave { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string sprite { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }

    }
}
