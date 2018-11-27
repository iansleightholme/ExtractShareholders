using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Share
    {
        public int Quantity;

        public string Description;

        public string Owner;

        public string OwnerType;

        public Share(string description, int quantity, string owner, string type)
        {
            Description = description;
            Quantity = quantity;
            Owner = owner;
            OwnerType = type;
        }
    }
}
