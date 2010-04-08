using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CouchDbDemo.Shared;
using CouchDbDemo.Shared.Clothes;
using RedBranch.Hammock;
using RedBranch.Hammock.Design;

namespace CouchDbDemo.Sandbox
{
    public class ClothesExample
    {
        private readonly Connection _connection;
        private Session _session;

        public ClothesExample()
        {
            _connection = new Connection(new Uri(Config.HOST));
        }

        public void Run()
        {
            if (_connection.ListDatabases().Contains(Config.CLOTHES_DB_NAME))
            {
                _connection.DeleteDatabase(Config.CLOTHES_DB_NAME);
            }

            _connection.CreateDatabase(Config.CLOTHES_DB_NAME);

            _session = _connection.CreateSession(Config.CLOTHES_DB_NAME);

            Debug.WriteLine("-- Running CreateClothes --" + Environment.NewLine);
            CreateClothes();

            Debug.WriteLine("-- Running CreateMapFunctions --" + Environment.NewLine);
            CreateMapFunctions();

            Debug.WriteLine("-- Running QueryByKey --" + Environment.NewLine);
            QueryByKey();
        }

        private void CreateClothes()
        {
            _session.Save(new ClothingType
                              {
                                  Color = "Red",
                                  DatePurchased = DateTime.Now,
                                  Description = "Prom gown",
                                  Name = "Anna Sui dress"
                              });

            _session.Save(new ClothingType
                              {
                                  Color = "Black",
                                  DatePurchased = DateTime.Parse("3/7/2010"),
                                  Description = "Tux for prom",
                                  Name = "Claiborne tuxedo"
                              });

            _session.Save(new ClothingType
                              {
                                  Color = "White",
                                  DatePurchased = DateTime.Parse("11/14/2004"),
                                  Description = "dress shoes",
                                  Name = "Donna Karan (DKNY) shoes"
                              });

            _session.Save(new ClothingType
                              {
                                  Color = "Blue",
                                  DatePurchased = DateTime.Parse("1/1/2010"),
                                  Description = "sneakers",
                                  Name = "Diesel shoes"
                              });

            _session.Save(new ClothingType
                              {
                                  Color = "Red",
                                  DatePurchased = DateTime.Parse("8/2/2007"),
                                  Description = "Red/white striped tie",
                                  Name = "Converse Tie"
                              });

            _session.Save(new ClothingType
                              {
                                  Color = "Blue",
                                  DatePurchased = DateTime.Parse("7/25/2008"),
                                  Description = "jeans",
                                  Name = "Levi Jeans"
                              });
        }

        private void CreateMapFunctions()
        {
            string mapFunction = File.ReadAllText("Scripts/clothing-color-search-map.js");

            DesignDocument designDocument = new DesignDocument();

            designDocument.Language = "javascript";

            designDocument.Views = new Dictionary<string, View>();

            designDocument.Views.Add("color-search", new View() { Map = mapFunction });

            _session.Save(designDocument, "_design/clothes-queries-by-color");
        }

        private void QueryByKey()
        {
            Query<ClothingType>.Result q =
                new Query<ClothingType>(_session, "clothes-queries-by-color", "color-search", false).From("Blue").To(
                    "Blue").
                    Execute();

            foreach (Query<ClothingType>.Result.Row result in q.Rows)
            {
                ClothingType clothingType = result.Entity;

                Debug.WriteLine(clothingType.ToString() + Environment.NewLine);
            }
            Console.WriteLine("Press a key to continue");

            Console.ReadKey();
        }
    }
}