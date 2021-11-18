using MVCAsset.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsset.Controllers
{
    public class DisabledDeviceController : Controller
    {
        // GET: DisabledDevice
        Context c = new Context();
        public ActionResult Index()
        {
            var val = c.Devices.Where(x => x.DevExist == false && x.DeviceID!=0).ToList();
            return View(val);
        }
        public ActionResult Delete(int id)
        {
            var val = c.Devices.Find(id);
            c.Devices.Remove(val);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult Recover(int id) 
        {
            var val = c.Devices.Find(id);
            val.DevExist = true;
            c.SaveChanges();
            return RedirectToAction("Index"); 
        
        }
    }
}