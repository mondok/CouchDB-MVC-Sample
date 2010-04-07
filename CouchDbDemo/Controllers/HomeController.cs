using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CouchDbDemo.Models;
using CouchDbDemo.Shared;
using CouchDbDemo.Shared.Clothes;
using RedBranch.Hammock;


namespace DbWeb.Controllers
{
    public class HomeController : Controller
    {
        private Session _session;

        public HomeController()
        {
            Connection connection = new Connection(new Uri(Config.HOST));
            _session = connection.CreateSession(Config.CLOTHES_DB_NAME);
        }

        public ActionResult Index()
        {
            List<ClothingTypeDto> clothingTypes =
                new Query<ClothingType>(_session, "clothes-queries", "all-clothes", false)
                    .All()
                    .Execute()
                    .Rows
                    .Select(r => new ClothingTypeDto
                                     {
                                         Color = r.Entity.Color,
                                         DatePurchased = r.Entity.DatePurchased,
                                         Description = r.Entity.Description,
                                         EntityType = r.Entity.EntityType,
                                         Id = r.Id,
                                         Name = r.Entity.Name
                                     })
                    .ToList();

            return View(clothingTypes);
        }

        public ActionResult ColorsBreakdown()
        {
            List<ClothingColor> colors = new List<ClothingColor>();

            var result =
                new Query<ClothingType>(_session, "clothes-queries", "colors-breakdown", true).All().Execute();

            foreach (var row in result.Rows)
            {
                ClothingColor color = new ClothingColor { Color = (string)row.Key };
                color.Count = (int)row.Value;
                colors.Add(color);
            }

            return View(colors);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateClothingType(ClothingTypeDto clothingTypeDto)
        {
            ClothingType clothingType = Mapper.Map<ClothingTypeDto, ClothingType>(clothingTypeDto);
            _session.Save(clothingType);
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CreateClothingType()
        {
            return View(new ClothingTypeDto());
        }

        public ActionResult ClothingTypeDetails(string id)
        {
            ClothingType clothingType = _session.Load<ClothingType>(id);
            ClothingTypeDto clothingTypeDto = Mapper.Map<ClothingType, ClothingTypeDto>(clothingType);

            clothingTypeDto.Id = id;
            return View(clothingTypeDto);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditClothingType(string id)
        {
            ClothingType clothingType = _session.Load<ClothingType>(id);
            ClothingTypeDto clothingTypeDto = Mapper.Map<ClothingType, ClothingTypeDto>(clothingType);
            clothingTypeDto.Id = id;
            return View(clothingTypeDto);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditClothingType(ClothingTypeDto clothingTypeDto)
        {
            ClothingType clothingType = _session.Load<ClothingType>(clothingTypeDto.Id);

            clothingType = Mapper.Map<ClothingTypeDto, ClothingType>(clothingTypeDto, clothingType);

            _session.Save(clothingType, clothingTypeDto.Id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClothingType(string id)
        {
            ClothingType clothingType = _session.Load<ClothingType>(id);
            _session.Delete(clothingType);
            return RedirectToAction("Index");
        }

    }
}
