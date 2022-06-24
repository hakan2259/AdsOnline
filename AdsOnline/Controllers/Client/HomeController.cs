using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AdsOnline.Controllers
{
    public class HomeController : Controller
    {
        AdsContext context = new AdsContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
          

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return View();
        }
        public PartialViewResult SearchPartial()
        {
           
            return PartialView();
        }
        public ActionResult GetSearchAdvert(string p)
        {
            
            var values = from x in context.Adverts select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.Title.Contains(p) || y.Description.Contains(p));

            }
            var categories = context.Categories.ToList();
            ViewData["categories"] = categories;
            return View(values.ToList());
        }

        public ActionResult GetSearchAdvertPriceRange(decimal minPrice,decimal maxPrice)
        {

            var values = from x in context.Adverts select x;
           
            values = values.Where(y => y.Price >= minPrice && y.Price <= maxPrice);

            var categories = context.Categories.ToList();
            ViewData["categories"] = categories;
            return View(values.ToList());
        }

        public PartialViewResult CategoryPartial()
        {
            var categories = context.Categories.ToList();
            return PartialView(categories);
        }
        public ActionResult GetAdvertByCategory(int id)
        {
            var adverts = context.Adverts.Where(x => x.CategoryId == id).ToList();
            var categories = context.Categories.ToList();
            ViewData["categories"] = categories;

            return View(adverts);
          
        }
        public PartialViewResult SubscribePartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var informations = context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.Email, false);
                Session["UserMail"] = informations.Email.ToString();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}