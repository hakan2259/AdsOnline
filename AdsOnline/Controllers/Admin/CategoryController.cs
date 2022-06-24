using AdsOnline.Models.Data;
using AdsOnline.Models.Data.Abstract;
using AdsOnline.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsOnline.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
      
     
        public ActionResult Index()
        {
            using(var context = new AdsContext())
            {
                var categories = context.Categories.ToList();
                return View(categories);
            }

        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            using (var context = new AdsContext())
            {
                context.Categories.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult DeleteCategory(int id)
        {
            using (var context = new AdsContext())
            {
                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetCategory(int id)
        {
            using (var context = new AdsContext())
            {
                var category = context.Categories.Find(id);
                return View("GetCategory", category);
            }
        }

        public ActionResult UpdateCategory(Category c)
        {
            using (var context = new AdsContext())
            {
                var category = context.Categories.Find(c.Id);
                category.Name = c.Name;
                category.Description = c.Description;
                category.Icon = c.Icon;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        
    }
}