using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Fakes
{
    public class FakePdfReader : DAL.IPdfReader
    {
        public string GetAllText(Uri uri)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string location = $"Fakes.PdfContents.{GetFileName(uri)}";
            using (Stream stream = assembly.GetManifestResourceStream(location))
            using (StreamReader reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

        string GetFileName(Uri uri)
        {
            switch(uri.ToString())
            {
                case "https://www.kompany.com.mt/product/report/pdf/REPRG/UK/04422335/1543071441/en?is_brex=1&suppress_cover_sheet=1":
                    return "ConfirmationStatement_MassMediaDesign.txt";
                case "https://www.kompany.com.mt/product/report/pdf/REPRG/UK/09145711/1543072842/en?is_brex=1&suppress_cover_sheet=1":
                    return "ConfirmationStatement_AimBrainSolutions.txt";
                case "https://www.kompany.com.mt/product/report/pdf/REPRG/AT/472283I/1543074537/en?is_brex=1&suppress_cover_sheet=1":
                    return "Statement_PaySafe.txt";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
