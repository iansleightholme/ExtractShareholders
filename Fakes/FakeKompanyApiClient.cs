using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fakes
{
    public class FakeKompanyApiClient : DAL.IKompanyApiClient
    {
        public string SearchByNumber(string countryCode, string id)
        {
            string filename = $"./HttpResponses/SearchByNumber/{countryCode.ToUpper()}_{id.ToUpper()}.json";
            return ReadFile(filename);
        }

        public string GetAnouncements(string id)
        {
            string filename = $"./HttpResponses/Announcements/{id}.json";
            return ReadFile(filename);
        }

        public string GetCompanyFull(string id)
        {
            string filename = $"./HttpResponses/Full/{id}.json";
            return ReadFile(filename);
        }

        public string ProductSearch(string id) 
        {
            string filename = $"./HttpResponses/ProductSearch/{id}.json";
            return ReadFile(filename);
        }

        public string ProductOrder(string sku, string id)
        {
            string filename = $"./HttpResponses/ProductOrder/{sku}_{id}.json";
            return ReadFile(filename);
        }

        public string GetProduct(string id)
        {
            string filename = $"./HttpResponses/Product/{id}.json";
            return ReadFile(filename);
        }

        string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}