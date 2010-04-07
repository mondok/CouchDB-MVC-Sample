using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CouchDbDemo.Shared.Pets
{
    public class Pet
    {
        public string Owner_Id { get; set; }

        public string PetName { get; set; }

        public string PetType { get; set; }

        public override string ToString()
        {
            return string.Format("Pet Name: {0}, Pet Type: {1}, Owner ID:{2}", this.PetName, this.PetType, this.Owner_Id);
        }
    }
}
