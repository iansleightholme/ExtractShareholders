using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Company
    {
        public string id;
        public string country;
        public string registrationNumber;
        public string name;
        public string status;
        public IList<string> address;
        public DateTime lastAnnouncementDate;
    }
}
