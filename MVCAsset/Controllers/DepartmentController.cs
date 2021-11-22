using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAsset.Models.Classes;

namespace MVCAsset.Controllers
{
    
    public class DepartmentController : Controller
    {
        // GET: Department
        readonly Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Departments.Where(x => x.DepExisist == true).ToList();

            return View(val);
        }

        [HttpGet]
        [Authorize(Roles = "A,B")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
   
        public ActionResult Add(Department p)
        {
            var val = c.Departments.FirstOrDefault(x => x.DepName == p.DepName);
            if (val != null)
            {
              
                ViewBag.msg = "Department already exist, try enter different ";
                return View();
            }
            else
            {
                p.DepExisist = true;
                c.Departments.Add(p);
                c.SaveChanges();

            }
            return RedirectToAction("Index");


        }
        [Authorize(Roles = "A")]
        public ActionResult Delete(int id)
        {

            var val = c.Departments.Find(id);

            c.Departments.Remove(val);
            c.SaveChanges();


            return RedirectToAction("Index");

        }
        [Authorize(Roles ="A,B")]
        public ActionResult GetDep(int id)
        {
            var dep = c.Departments.Find(id);

            return View("GetDep", dep);


        }
        public ActionResult Update(Department p)
        {
            var dep = c.Departments.Find(p.DepartmentID);
            dep.DepName = p.DepName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detalis(int id)
        {
            var val = c.Employees.Where(x => x.DepartmentID == id).ToList();
            var viv = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepName).FirstOrDefault();
            var valu = c.Employees.Where(x => x.DepartmentID == id).Count().ToString();
            ViewBag.cnt = valu;
            ViewBag.dpn = viv;
            return View("Detalis", val);
        }


    }
}