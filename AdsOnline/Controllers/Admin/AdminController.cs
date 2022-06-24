using AdsOnline.Models.Data;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdsOnline.Controllers
{
    
    public class AdminController : Controller
    {
        AdsContext context = new AdsContext();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult DashBoard()
        {
            return View();
        }
  
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var admin = context.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if(admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"] = admin.UserName.ToString();
                return RedirectToAction("DashBoard", "Admin");

            }
            return RedirectToAction("Login","Admin");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }
        [Authorize]
        public ActionResult User()
        {
            var users = context.Users.Where(x => x.Status == true).ToList();
            return View(users);
        }
        [Authorize(Roles = "A")]
        public ActionResult GetAdmins()
        {
            var admins = context.Admins.ToList();
            return View(admins);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult CreateAdmin()
        {

            return View();
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult CreateAdmin(Admin a)
        {

            context.Admins.Add(a);
            context.SaveChanges();
            return RedirectToAction("GetAdmins", "Admin");
        }
        [Authorize(Roles = "A")]
        public ActionResult GetAdmin(int id)
        {

            var admin = context.Admins.Find(id);
            return View("GetAdmin", admin);

        }
        [Authorize(Roles = "A")]
        public ActionResult UpdateAdmin(Admin a)
        {
           
            var admin = context.Admins.Find(a.Id);
            admin.UserName = a.UserName;
            admin.Password = a.Password;
            admin.Authority = a.Authority;

            context.SaveChanges();
            return RedirectToAction("GetAdmins", "Admin");
        }
        [Authorize(Roles = "A")]
        public ActionResult DeleteAdmin(int id)
        {
           
                var admin = context.Admins.Find(id);
                context.Admins.Remove(admin);
                context.SaveChanges();
                return RedirectToAction("GetAdmins","Admin");
            
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateUser()
        {
            
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/Users/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                user.Image = "/Images/Users/" + filename + extension;

            }
            user.Status = true;
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("User","Admin");
        }
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            user.Status = false;
            context.SaveChanges();
            return RedirectToAction("User","Admin");
        }
        [Authorize]
        public ActionResult GetUser(int id)
        {
           
            var user = context.Users.Find(id);
            return View("GetUser", user);

        }
        [Authorize]
        public ActionResult UpdateUser(User u)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Images/Users/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                u.Image = "/Images/Users/" + filename + extension;

            }
            var user = context.Users.Find(u.Id);
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
            user.Image = u.Image;
            user.Email = u.Email;
            user.Password = u.Password;
            user.Phone = u.Phone;
            user.Address = u.Address;

            context.SaveChanges();
            return RedirectToAction("User","Admin");
        }
        public ActionResult GetContacts()
        {
            var contact = context.Contacts.ToList();
            return View(contact);
        }
        public ActionResult DeleteContact(int id)
        {

            var contact = context.Contacts.Find(id);
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("GetContacts", "Admin");

        }
    }
}