using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMachineDetails()
        {
            using (TCMSDBEntities tm = new TCMSDBEntities())
            {
                var computers = tm.computers.OrderBy(a => a.MachineNO).ToList();
                return Json(new { data = computers }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (TCMSDBEntities dc = new TCMSDBEntities())
            {

                var v = dc.computers.Where(a => a.MachineNO == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(computer com)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (TCMSDBEntities dc = new TCMSDBEntities())
                {

                    if (com.MachineNO > 0)
                    {
                        // Edit
                        var v = dc.computers.Where(a => a.MachineNO == com.MachineNO).FirstOrDefault();
                        if (v != null)
                        {
                            v.MachineNO = com.MachineNO;
                            v.Processor_Type = com.Processor_Type;
                            v.HDD_Capacity = com.HDD_Capacity;
                            v.RAM_Capacity = com.RAM_Capacity;
                            v.PowerSupply_ID = com.PowerSupply_ID;
                            v.Motherboard_ID = com.Motherboard_ID;
                            v.LabNo = com.LabNo;
                        }
                        else
                        {

                            //Save
                            dc.computers.Add(com);

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
            //return Json(new { status = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {


            using (TCMSDBEntities dc = new TCMSDBEntities())
            {
                computer aa = new computer();
                var v = dc.computers.Where(a => a.MachineNO == id).FirstOrDefault();
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
                var v = dc.computers.Where(a => a.MachineNO == id).FirstOrDefault();
                if (v != null)
                {
                    dc.computers.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status, message = "Computer Details Deleted Successfully" } };
        }
    }
}