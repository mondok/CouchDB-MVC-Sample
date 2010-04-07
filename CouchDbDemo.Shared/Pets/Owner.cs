using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouchDbDemo.Shared.Pets
{
    public class Owner
    {
        public string OwnerName { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return string.Format("Owner Name: {0}, City: {1}", this.OwnerName, this.City);
        }
    }
}
