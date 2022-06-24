using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsOnline.Controllers
{
    [Authorize]
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
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/Adverts/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                advert.Image = "/Images/Adverts/" + filename + extension;
            }
            advert.AdvertDate = DateTime.Now;
            advert.UserId = 3;
            advert.Status = true;
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
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/Adverts/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                a.Image = "/Images/Adverts/" + filename + extension;

            }
            var advert = context.Adverts.Find(a.Id);
            advert.Title = a.Title;
            advert.Description = a.Description;
            advert.Price = a.Price;
            advert.AdvertDate = a.AdvertDate;
            advert.Status = true;
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