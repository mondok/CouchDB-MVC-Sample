using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CouchDbDemo.Shared;
using CouchDbDemo.Shared.Pets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedBranch.Hammock;
using RedBranch.Hammock.Design;

namespace CouchDbDemo.Sandbox
{
    public class PetExample
    {
        private readonly Connection _connection;
        private Session _session;

        public PetExample()
        {
            _connection = new Connection(new Uri(Config.HOST));
        }

        public void Run()
        {
            if (_connection.ListDatabases().Contains(Config.PET_DB_NAME))
                _connection.DeleteDatabase(Config.PET_DB_NAME);

            _connection.CreateDatabase(Config.PET_DB_NAME);

            _session = _connection.CreateSession(Config.PET_DB_NAME);

            Debug.WriteLine("-- Running CreatePets --" + Environment.NewLine);
            CreatePets();

            Debug.WriteLine("-- Running CreateMapFunctions --" + Environment.NewLine);
            CreateMapFunctions();

            Debug.WriteLine("-- Running QueryForOwnerAndPets --" + Environment.NewLine);
            QueryForOwnerAndPets();
        }

        private void QueryForOwnerAndPets()
        {
            Query<object> petJoin = new Query<object>(_session, "owner-queries", "owner-map", false);

            Query<object>.Spec petResult = petJoin.From(CreateToken("[\"Sam\"]")).To(CreateToken("[\"Sam\",{}]"));

            Debug.WriteLine(string.Format("CouchDB uri is {0}" + Environment.NewLine, petResult));

            Debug.Write(string.Format("CouchDB uri is {0}" + Environment.NewLine, petResult));

            foreach (Query<object>.Result.Row row in petResult.Execute().Rows)
            {
                if (row.Entity is Owner)
                {
                    Owner owner = (Owner) row.Entity;

                    Debug.WriteLine(owner.ToString() + Environment.NewLine);
                }
                else
                {
                    Pet pet = (Pet) row.Entity;

                    Debug.WriteLine(pet.ToString() + Environment.NewLine);
                }
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        private void CreateMapFunctions()
        {
            string mapFunction = File.ReadAllText("Scripts/owner-map.js");

            DesignDocument designDocument = new DesignDocument {Language = "javascript"};

            designDocument.Views = new Dictionary<string, View>();

            View view = new View {Map = mapFunction};

            designDocument.Views.Add("owner-map", view);

            _session.Save(designDocument, "_design/owner-queries");
        }

        private void CreatePets()
        {
            _session.Save(new Pet {Owner_Id = "Harold", PetName = "Cody", PetType = "Dog"});
            _session.Save(new Pet {Owner_Id = "Harold", PetName = "Ronnie", PetType = "Dog"});
            _session.Save(new Pet {Owner_Id = "Harold", PetName = "Max", PetType = "Dog"});
            _session.Save(new Pet {Owner_Id = "Harold", PetName = "Ziggy", PetType = "Dog"});
            _session.Save(new Pet {Owner_Id = "Sam", PetName = "Bell", PetType = "Cat"});
            _session.Save(new Pet {Owner_Id = "Sam", PetName = "Murphy", PetType = "Dog"});
            _session.Save(new Owner {OwnerName = "Harold", City = "Philadelphia"});
            _session.Save(new Owner {OwnerName = "Sam", City = "Trenton"});
        }

        private JToken CreateToken(string value)
        {
            JsonReader reader = new JsonTextReader(new StringReader(value));

            return JToken.ReadFrom(reader);
        }
    }
}