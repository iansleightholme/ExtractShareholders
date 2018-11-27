using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Fakes;
using Newtonsoft.Json;

namespace Model
{
    public class Model
    {
        IKompanyApiClient apiClient = new Fakes.FakeKompanyApiClient();     // Fakes  new KompanyApiClient("password"); //  
        IPdfReader pdfReader = new Fakes.FakePdfReader();                   // Fakes
        ReportReader reportReader = new ReportReader();

        public ShareRegister GetShareRegister(string countryCode, string companyNumber)
        {
            // Retrieve the company details from Kompany
            CompanyRegistration details = GetCompanyRegistration(countryCode, companyNumber);

            // Order the report from Kompany
            Uri reportUri = OrderReport(countryCode, details.id);

            // Download the document
            //byte[] report = DownloadReport;

            // Extract the contents to text
            string reportText = pdfReader.GetAllText(reportUri);

            // Extract shares from the report text
            List<Share> shares = reportReader.GetShares(reportText, countryCode).ToList();

            return new ShareRegister()
            {
                CountryCode = countryCode,
                CompanyNumber = companyNumber,
                Shares = shares
            };
        }

        CompanyRegistration GetCompanyRegistration(string countryCode, string companyNumber)
        {
            string detailsJson = apiClient.SearchByNumber(countryCode, companyNumber);
            return JsonConvert.DeserializeObject<IList<CompanyRegistration>>(detailsJson).First();
        }

        Uri OrderReport(string countryCode, string companyId)
        {
            string announcementsJson = apiClient.GetAnouncements(companyId);
            IList<Announcement> announcements = JsonConvert.DeserializeObject<IList<Announcement>>(announcementsJson);

            string fullJson = apiClient.GetCompanyFull(companyId);
            Company company = JsonConvert.DeserializeObject<Company>(fullJson);

            string productSearchJson = apiClient.ProductSearch(companyId);
            IList<ProductSearch> productSearch = JsonConvert.DeserializeObject<IList<ProductSearch>>(productSearchJson);

            string productOrderJson = apiClient.ProductOrder(GetSku(countryCode), companyId);
            ProductOrder productOrder = JsonConvert.DeserializeObject<ProductOrder>(productOrderJson);

            string productJson = apiClient.GetProduct(productOrder.identity);
            Product product = JsonConvert.DeserializeObject<Product>(productJson);

            return new Uri(product.uri);
        }

        string GetSku(string countryCode)
        {
            switch (countryCode.ToUpper())
            {
                case "GB":
                    return "REPOFCHUK";
                case "AT":
                    return "REPOFHFAT";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

