using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouchDbDemo.Shared.Clothes
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

        public override string ToString()
        {
            return string.Format("Color: {0}, Name: {1}, Description: {2}, Date Purchased: {3}, Entity Type: {4}", this.Color, this.Name,
                                 this.Description, this.DatePurchased, this.EntityType);
        }
    }
}