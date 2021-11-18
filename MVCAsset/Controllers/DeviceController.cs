using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device

        readonly Context c = new Context();

        public ActionResult Index()
        {
            var val = c.Devices.Where(x => x.DevExist == true).ToList();
            return View(val);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Device p)
        {
          var val = c.Devices.FirstOrDefault(x => x.DevName == p.DevName);
            var valu = c.Devices.FirstOrDefault(x => x.SerialNumber == p.SerialNumber);
            if (val != null)
            {
                ViewBag.ms = "Device already exisit ";
                return View();

            }
            if (valu != null)
            {
                ViewBag.msser = "Product number is unique for devices ";
                return View();

            }
            else
            {
                p.DevExist = true;
                c.Devices.Add(p);
                c.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public ActionResult Disable(int id)
        {
            var val = c.Devices.Find(id);
            val.DevExist = false;
            c.SaveChanges();


            return RedirectToAction("index");
        }
        public ActionResult GetDev(int id)
        {
            var val = c.Devices.Find(id);

            return View("GetDev", val);
        }

     
        public ActionResult Update(Device p)
        {
         
                var value = c.Devices.Find(p.DeviceID);
                value.DevName = p.DevName;
                value.SerialNumber = p.SerialNumber;
                value.Description = p.Description;
                c.SaveChanges();
         
            return RedirectToAction("Index");

        }
        public ActionResult Index2() //This index is for Pdf Excell 
        {
            var val = c.Devices.Where(x => x.DevExist == true).ToList();
            return View(val);
        }
    }
}