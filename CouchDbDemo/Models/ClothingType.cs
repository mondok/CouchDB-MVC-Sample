using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouchDbDemo.Models
{
    public class ClothingType
    {
        public string EntityType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public DateTime DatePurchased { get; set; }

        public ClothingType()
        {
            this.EntityType = "clothes";
        }
    }
}