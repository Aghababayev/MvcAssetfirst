using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAsset.Controllers
{
    [AllowAnonymous]
    
    public class SecurityController : Controller


    { Context c = new Context();
        // GET: Security
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)

        {
        
         
            var usr = c.Users.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
       
            if (usr != null)
            {
                Session["user"] = usr.Username.ToString();
                Session["prm"] = usr.Permission.ToString();
                FormsAuthentication.SetAuthCookie(usr.Username,false);
              
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                ViewBag.msg = "Invalid username or password. Please try again...";
                return View();
            }

        }
        public ActionResult Logout()
        {
          
            FormsAuthentication.SignOut();
           
    
            return RedirectToAction("Login");
        }
       
    }
}