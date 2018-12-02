using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fakes
{
    public class FakeKompanyApiClient : DAL.IKompanyApiClient
    {
        public string SearchByNumber(string countryCode, string id)
        {
            return ReadFile($"SearchByNumber.{countryCode.ToUpper()}_{id.ToUpper()}.json");
        }

        public string GetAnouncements(string id)
        {
            return ReadFile($"Announcements.{id}.json");
        }

        public string GetCompanyFull(string id)
        {
            return ReadFile($"Full.{id}.json");
        }

        public string ProductSearch(string id) 
        {
            return ReadFile($"ProductSearch.{id}.json");
        }

        public string ProductOrder(string sku, string id)
        {
            return ReadFile($"ProductOrder.{sku}_{id}.json");
        }

        public string GetProduct(string id)
        {
            return ReadFile($"Product.{id}.json");
        }

        string ReadFile(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string location = "Fakes.HttpResponses." + path;
            using (Stream stream = assembly.GetManifestResourceStream(location))
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}