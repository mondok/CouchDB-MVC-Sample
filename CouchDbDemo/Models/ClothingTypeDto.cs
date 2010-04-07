using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouchDbDemo.Models
{
    public class ClothingTypeDto
    {
        public string Id { get; set; }

        public string EntityType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public DateTime DatePurchased { get; set; }

        public ClothingTypeDto()
        {
            this.EntityType = "clothes";
        }
    }
}