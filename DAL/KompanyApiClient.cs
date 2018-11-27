using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DAL
{
    public class KompanyApiClient : IKompanyApiClient
    {
        Uri baseUri = new Uri("https://api.brex.io/api/v1/");
        string key;

        public KompanyApiClient(string key)
        {
            this.key = key;
        }

        public string GetAnouncements(string id)
        {
            return GetResponse($"company/{id}/announcements");
        }

        public string GetCompanyFull(string id)
        {
            return GetResponse($"company/{id}/full");
        }

        public string GetProduct(string id)
        {
            return GetResponse($"product/{id}");
        }

        public string ProductOrder(string sku, string id)
        {
            return GetResponse($"product/order/{sku}/{id}");
        }

        public string ProductSearch(string id)
        {
            return GetResponse($"product/search/{id}");
        }

        public string SearchByNumber(string countryCode, string id)
        {
            return GetResponse($"company/deepsearch/name/{countryCode}/{id}");
        }

        string GetResponse(string relativeUri)
        {
            Uri fullUri = new Uri(baseUri, relativeUri);

            var client = new WebClient();
            client.Headers.Add($"user_key:{key}");

            return client.DownloadString(fullUri.ToString());
        }
    }
}
