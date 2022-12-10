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
        public string ability { get; set; }
        public int dex { get; set; }
        public string image { get; set; }
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string sprite { get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }

    }
}
