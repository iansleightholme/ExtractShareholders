using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductSearch
    {
        public string sku;
        public string description;
        public Single? price;
        public string type;
        public string category;
        public string provider;
        public string countryCode;
        public bool hasOptions;
        public IList<string> options;
        public string availability;
    }
}
