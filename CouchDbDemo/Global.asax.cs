using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CouchDbDemo.Models;
using CouchDbDemo.Shared;
using CouchDbDemo.Shared.Clothes;
using RedBranch.Hammock;
using RedBranch.Hammock.Design;

namespace CouchDbDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        private void InitDb()
        {
            Connection connection = new Connection(new Uri(Config.HOST));

            connection.DeleteDatabase(Config.CLOTHES_DB_NAME);

            //if (!connection.ListDatabases().Any(db => db == Config.CLOTHES_DB_NAME))
            //{
            connection.CreateDatabase(Config.CLOTHES_DB_NAME);

            Session session = connection.CreateSession(Config.CLOTHES_DB_NAME);

            string allClothesScript =
                File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/all-clothes-map.js"));

            string colorsMap =
                File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/colors-map.js"));

            string colorsReduce =
                File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/colors-reduce.js"));

            session.Save(
                 new DesignDocument
                 {
                     Language = "javascript",
                     Views = new Dictionary<string, View>
                                     {
                                        { "all-clothes", new View {
                                            Map = allClothesScript
                                        }},
                                        { "colors-breakdown", new View
                                                        {
                                                            Map = colorsMap,
                                                            Reduce = colorsReduce
                                                        }}
                                     }
                 },
                  "_design/clothes-queries"
             );
            //}
        }

        private void RegisterAutoMaps()
        {
            AutoMapper.Mapper.CreateMap(typeof(ClothingTypeDto), typeof(ClothingType));
            AutoMapper.Mapper.CreateMap(typeof(ClothingType), typeof(ClothingTypeDto));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            InitDb();

            RegisterAutoMaps();
        }
    }
}