using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Infra.MongoDB
{
    public class MongoDBOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
