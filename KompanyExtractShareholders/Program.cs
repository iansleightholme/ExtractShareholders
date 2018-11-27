using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Fakes;
using DAL;
using Model;

// **** For Experimentation ****
namespace KompanyExtractShareholders
{
    class Program
    {
        static void Main(string[] args)
        {
            Model.Model model = new Model.Model();
            ShareRegister register = model.GetShareRegister("at", "472283i");  //04994880  472283i  "gb", "09145711"
            //ShareRegister register = model.GetShareRegister("GB", "09145711");  //04994880  472283i  
            //string contents = reader.GetAllText(new Uri(uri));
        }
    }
}