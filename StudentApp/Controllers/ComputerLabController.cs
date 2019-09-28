using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ComputerLabController : Controller
    {
        // GET: Lab
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLabDetails()
        {
            using (TCMSDBEntities tm = new TCMSDBEntities())
            {
                var labs = tm.labs.OrderBy(a => a.LabNo).ToList();
                return Json(new { data = labs }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (TCMSDBEntities dc = new TCMSDBEntities())
            {

                var v = dc.labs.Where(a => a.LabNo == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(lab com)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (TCMSDBEntities dc = new TCMSDBEntities())
                {

                    if (com.LabNo > 0)
                    {
                        // Edit
                        var v = dc.labs.Where(a => a.LabNo == com.LabNo).FirstOrDefault();
                        if (v != null)
                        {
                            v.LabNo = com.LabNo;
                            v.floor = com.floor;
                        }
                        else
                        {

                            //Save
                            dc.labs.Add(com);

                        }

                    }
                    try
                    {

                        dc.SaveChanges();
                        status = true;

                    }
                    catch (Exception)
                    {
                        status = true;
                        return new JsonResult { Data = new { status = status, message = "Something Wrong!" } };
                        throw;
                    }
                }
            }
            return new JsonResult { Data = new { status = status, message = "Saved Successfully" } };

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            using (TCMSDBEntities dc = new TCMSDBEntities())
            {
                lab aa = new lab();
                var v = dc.labs.Where(a => a.LabNo == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMachine(int id)
        {
            bool status = false;
            using (TCMSDBEntities dc = new TCMSDBEntities())
            {
                var v = dc.labs.Where(a => a.LabNo == id).FirstOrDefault();
                if (v != null)
                {
                    dc.labs.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status, message = "Lab Details Deleted Successfully" } };
        }
    }
}