using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{
    public class DisabledUserController : Controller
    {
        // GET: DisabledUser
        Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Employees.Where(x => x.EmpExsist == false && x.EmployeeID!=0).ToList();
            return View(val);
        }
        public ActionResult Delete(int id)
        {
            var val = c.Employees.Find(id);
            c.Employees.Remove(val);
            c.SaveChanges();
            return RedirectToAction("Index");

        
        }
        public ActionResult Recover(int id)
        {
            var val = c.Employees.Find(id);
            val.EmpExsist = true;
            c.SaveChanges();
            return RedirectToAction("Index");

        
        
        }
    }
       
}