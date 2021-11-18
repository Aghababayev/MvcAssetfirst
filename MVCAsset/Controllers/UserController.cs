using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{    [Authorize(Roles ="A")]
    public class UserController : Controller
    {
        // GET: User
        Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Users.ToList();
            return View(val);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> item = new List<SelectListItem>()
             { new SelectListItem { Text="A"},
               new SelectListItem { Text="B"},
               new SelectListItem { Text="C"}

             };
            ViewBag.per = item;
            return View();
         
        }
        [HttpPost]
        public ActionResult Add(User p)
        {
            var val = c.Users.FirstOrDefault(x => x.Username == p.Username);
            if (val!=null)
            {
                ViewBag.ms = "Username already exist, try enter different";
                List<SelectListItem> item = new List<SelectListItem>()
             { new SelectListItem { Text="A"},
               new SelectListItem { Text="B"},
               new SelectListItem { Text="C"}

             };
                ViewBag.per = item;
                return View();
            }
            else
            {
                c.Users.Add(p);
                c.SaveChanges();

            }
          
        
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
         
            var val = c.Users.Find(id);
            c.Users.Remove(val);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUser(int id)
        {

            List<SelectListItem> item = new List<SelectListItem>()
             { new SelectListItem { Text="A"},
               new SelectListItem { Text="B"},
               new SelectListItem { Text="C"}

             };
            ViewBag.per = item;

            var val = c.Users.Find(id);
            return View("GetUser", val);
        
        }
        public ActionResult Update(User p)
        {
          
            var val = c.Users.Find(p.UserID);
            val.Username = p.Username;
            val.Password = p.Password;
            val.Permission = p.Permission;
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }


    }
}