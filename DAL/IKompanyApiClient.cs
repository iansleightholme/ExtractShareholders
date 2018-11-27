using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IKompanyApiClient
    {
        string SearchByNumber(string countryCode, string id);

        string GetAnouncements(string id);

        string GetCompanyFull(string id);

        string ProductSearch(string id);

        string ProductOrder(string sku, string id);

        string GetProduct(string id);
    }
}