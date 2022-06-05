using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsOnline.Controllers
{
    public class AdvertController : Controller
    {
        // GET: Advert
        AdsContext context = new AdsContext();
        public ActionResult Index()
        {
            var adverts = context.Adverts.Where(x => x.Status == true).ToList();
            return View(adverts);
            
        }
        [HttpGet]
        public ActionResult CreateAdvert()
        {
            List<SelectListItem> categories = (from c in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = c.Name,
                                                   Value = c.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdvert(Advert advert)
        {
            context.Adverts.Add(advert);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdvert(int id)
        {
            var advert = context.Adverts.Find(id);
            advert.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetAdvert(int id)
        {
            List<SelectListItem> categories = (from c in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = c.Name,
                                                   Value = c.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            var advert = context.Adverts.Find(id);
            return View("GetAdvert", advert);

        }
        public ActionResult UpdateAdvert(Advert a)
        {
            var advert = context.Adverts.Find(a.Id);
            advert.Title = a.Title;
            advert.Description = a.Description;
            advert.Price = a.Price;
            advert.AdvertDate = a.AdvertDate;
            advert.Status = a.Status;
            advert.Image = a.Image;
            advert.CategoryId = a.CategoryId;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAdvertDetail(int id)
        {
            var advert = context.Adverts.Find(id);
            return View("GetAdvertDetail", advert);

        }
    }
}