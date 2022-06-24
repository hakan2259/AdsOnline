using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AdsOnline.Controllers.Client
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: Use
        AdsContext context = new AdsContext();
        
        public ActionResult UserProfile()
        {
            var userMail = (string)Session["UserMail"];
            var values = context.Users.FirstOrDefault(x => x.Email == userMail);
            ViewBag.m = userMail;
            return View(values);
        }
   
        public ActionResult GetUserAdvert()
        {
            var userMail = (string)Session["UserMail"];
            var values = context.Users.FirstOrDefault(x => x.Email == userMail);
            var advertsUser = context.Adverts.Where(x => x.Status == true && x.UserId == values.Id).ToList();
            ViewBag.userFirstName = values.FirstName + values.LastName;
            return View("GetUserAdvert",advertsUser);

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
            advert.Status = a.Status;
            advert.Image = a.Image;
            advert.CategoryId = a.CategoryId;

            context.SaveChanges();
            return RedirectToAction("GetUserAdvert","User");
        }
    }
}