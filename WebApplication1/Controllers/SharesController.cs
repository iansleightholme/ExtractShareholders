using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DAL;
using Model;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class SharesController : ApiController
    {
        // GET api/shares/AT/472283i
        // Allowed values AT/472283i, GB/04994880 and GB/09145711 only
        public ShareRegister Get(string countryCode, string companyNumber)
        {
            Model.Model model = new Model.Model();

            return model.GetShareRegister(countryCode, companyNumber);
        }
    }
}