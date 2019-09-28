using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ComputerRepairController : Controller
    {
        // GET: Repaire
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRepairDetails()
        {
            using (TCMSDBEntities tm = new TCMSDBEntities())
            {
                var machines = tm.repairs.OrderBy(a => a.repair_id).ToList();
                return Json(new { data = machines }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (TCMSDBEntities dc = new TCMSDBEntities())
            {

                var v = dc.repairs.Where(a => a.repair_id == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(repair com)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (TCMSDBEntities dc = new TCMSDBEntities())
                {

                    if (com.MachineNO > 0)
                    {
                        // Edit
                        var v = dc.repairs.Where(a => a.MachineNO == com.MachineNO).FirstOrDefault();

                        if (v != null)
                        {
                            v.MachineNO = com.MachineNO;
                            v.cost = com.cost;
                            v.description = com.description;
                            v.repair_date = com.repair_date;

                        }
                        else
                        {

                            //Save
                            dc.repairs.Add(com);

                        }
                        try
                        {

                            dc.SaveChanges();
                            status = true;
                        }
                        catch (Exception)
                        {
                            status = false;
                            return new JsonResult { Data = new { status = status, message = "Invalid Machine Number.Please Check Computer Details Page" } };
                            throw;
                        }

                    }

                }

            }
            return new JsonResult { Data = new { status = status, message = "Saved Successfully" } };
            //return Json(new { status = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            using (TCMSDBEntities dc = new TCMSDBEntities())
            {
                computer aa = new computer();
                var v = dc.repairs.Where(a => a.repair_id == id).FirstOrDefault();
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
                var v = dc.repairs.Where(a => a.repair_id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.repairs.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status, message = "Repair Details Deleted Successfully" } };
        }
    }
}