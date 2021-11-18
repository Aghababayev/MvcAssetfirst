using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{
    
    public class EmployeeController : Controller
    {
        // GET: Employee
        readonly Context c = new Context();
     
        public ActionResult Index()
        {
            var val = c.Employees.Where(x => x.EmpExsist == true).ToList();
            var count = c.Employees.Where(x => x.EmpExsist == true).Count();
            ViewBag.cnt = count;
            return View(val);
        }
        public ActionResult Disable(int id)
        {
            var val = c.Employees.Find(id);
            val.EmpExsist = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> val = (from i in c.Departments.Where(x=>x.DepExisist==true).ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.DepName,
                                            Value = i.DepartmentID.ToString()


                                        }).ToList();
            ViewBag.value = val;


            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee p)

        {
            var valu = c.Employees.FirstOrDefault(x => x.ASL == p.ASL);
            if (valu != null)
            {
                ViewBag.ms = "ASL already exist, try enter different";
                List<SelectListItem> val = (from i in c.Departments.Where(x=>x.DepExisist==true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.DepName,
                                                Value = i.DepartmentID.ToString()


                                            }).ToList();
                ViewBag.value = val;
                return View();

            }
            else
            {
                p.EmpExsist = true;
                c.Employees.Add(p);
                c.SaveChanges();
            }
        

            return RedirectToAction("Index");
        }

        public ActionResult GetEmp(int id)
        {
            List<SelectListItem> value = (from i in c.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DepName,
                                              Value = i.DepartmentID.ToString()
                                          }).ToList();
            ViewBag.val = value;

            var emp = c.Employees.Find(id);
            return View("GetEmp", emp);
        }
        public ActionResult Update(Employee p)
        {
            var val = c.Employees.Find(p.EmployeeID);
            val.Name = p.Name;
            val.Surname = p.Surname;
            val.Position = p.Position;
            val.ASL = p.ASL;
            val.DepartmentID = p.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index2() //This index is for Pdf Excell 
        {
            var val = c.Employees.Where(x=>x.EmpExsist==true).ToList();
          
            return View(val);
        }
        
    }

}