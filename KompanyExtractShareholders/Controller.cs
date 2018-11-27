using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace KompanyExtractShareholders
{
    class Controller
    {
        IKompanyApiClient api= new Fakes.FakeKompanyApiClient();
        IPdfReader reader = new  Fakes.FakePdfReader();


        public Controller(IKompanyApiClient api)
        {
            this.api = api;
        }

        public void GetShareholding(string countryCode, string companyNumber)
        {
            throw new NotImplementedException();
        }
    }
}
