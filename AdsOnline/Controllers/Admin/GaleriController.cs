using AdsOnline.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsOnline.Controllers
{
    [Authorize]
    public class GaleriController : Controller
    {
        // GET: Galeri
        AdsContext context = new AdsContext();

        public ActionResult Index()
        {
            var adverts = context.Adverts.ToList();
            return View(adverts);
        }
    }
}