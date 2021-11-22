using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{
    public class HandoverController : Controller
    {
        // GET: Handover
        Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Handovers.ToList();
            return View(val);
        }
        public ActionResult Index2() //This index is for Pdf Excell 
        {
            var val = c.Handovers.ToList();
            return View(val);
        }
        [HttpGet]
        [Authorize(Roles = "A,B")]
        public ActionResult Add()
        {
            List<SelectListItem> empns = (from i in c.Employees.Where(i => i.EmpExsist == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name + " " + i.Surname,
                                              Value = i.EmployeeID.ToString()

                                          }
                                            ).OrderBy(x => x.Text).ToList();

            List<SelectListItem> dv = (from s in c.Devices.Where(s => s.DevExist == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = s.DevName,
                                           Value = s.DeviceID.ToString()


                                       }
                                       ).OrderBy(x => x.Text).ToList();

            ViewBag.ns = empns;
            ViewBag.dn = dv;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Handover p)
        {
           


            var hnd = c.Handovers.FirstOrDefault(x => x.SerialNumber == p.SerialNumber);
            if (hnd!=null)
            {
                ViewBag.msg = "Serial number must be unique, please try again";
                List<SelectListItem> empns = (from i in c.Employees.Where(i => i.EmpExsist == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name + " " + i.Surname,
                                                  Value = i.EmployeeID.ToString()

                                              }
                                          ).OrderBy(x => x.Text).ToList();

                List<SelectListItem> dv = (from s in c.Devices.Where(s => s.DevExist == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = s.DevName,
                                               Value = s.DeviceID.ToString()


                                           }
                                           ).OrderBy(x => x.Text).ToList();

                ViewBag.ns = empns;
                ViewBag.dn = dv;
                return View();
            }
            else
            {
                c.Handovers.Add(p);
                c.SaveChanges();
               
            }


            return RedirectToAction("Index");
        }
        [Authorize(Roles ="A")]
        public ActionResult Delete(int id)
        {
            var hnd = c.Handovers.Find(id);
            c.Handovers.Remove(hnd);
            c.SaveChanges();
            return RedirectToAction("index");

        }
             
    }


}