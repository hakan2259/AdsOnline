using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace AdsOnline.Controllers.Client
{
    
    public class ClientAdvertController : Controller
    {
        // GET: ClientAdvert
        AdsContext context = new AdsContext();
        public ActionResult Index()
        {
         
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateAdvert()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [Authorize]
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
            var mail = (string)Session["UserMail"];
            var adUser = context.Users.FirstOrDefault(x => x.Email == mail);
            advert.UserId = adUser.Id;
            advert.AdvertDate = DateTime.Now;
            context.Adverts.Add(advert);
            context.SaveChanges();

            return RedirectToAction("CreateAdvert", "ClientAdvert");
        }
        public ActionResult GetAdverts(int page=1)
        {

            //var adverts = context.Adverts.Where(x => x.Status == true).ToList();
            var adverts = context.Adverts.ToList().ToPagedList(page, 6);
        
        
            var categories = context.Categories.ToList();
            ViewData["categories"] = categories;
          
            return View(adverts);
         
        }
        public ActionResult GetAdvertsSort(string sortOrder)
        {

            //var adverts = context.Adverts.Where(x => x.Status == true).ToList();
            var adverts = from s in context.Adverts
                           select s;

            switch (sortOrder)
            {
                case "descPrice":
                    adverts = adverts.OrderByDescending(s => s.Price);
                    break;
                case "ascPrice":
                    adverts = adverts.OrderBy(s => s.Price);
                    break;
                case "ascAddress":
                    adverts = adverts.OrderBy(s => s.Address);
                    break;
                default:
                    adverts = adverts.OrderBy(s => s.Address);
                    break;
            }

            var categories = context.Categories.ToList();
            ViewData["categories"] = categories;
            return View(adverts.ToList());

        }
        public ActionResult GetAdvertDetail(int id)
        {
            var advert = context.Adverts.Find(id);
            var adUser = context.Users.FirstOrDefault(x => x.Id == advert.UserId);
            ViewBag.userFirstName = adUser.FirstName + adUser.LastName;
            ViewBag.userMail = adUser.Email;
            return View("GetAdvertDetail",advert);

        }
    }
}