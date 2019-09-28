using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TMSApp.Controllers
{
    public class AllocationController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Allocation
        public ActionResult Index(string Day, string C_id, string S_Time_hh, string S_Time_mm, string E_Time_hh, string E_Time_mm)
        {


            var hh_list = new List<string>();
            hh_list.Add("");
            for (int x = 0; x <= 23; x++)
            {

                if (x <= 9)
                {
                    hh_list.Add("0" + x);
                }
                else
                {
                    hh_list.Add(x.ToString());
                }
            }


            var mm_list = new List<string>();
            mm_list.Add("");
            for (int x = 0; x <= 59; x++)
            {

                if (x <= 9)
                {
                    mm_list.Add("0" + x);
                }
                else
                {
                    mm_list.Add(x.ToString());
                }
            }



            var Day_list = new List<string>();

            Day_list.Add("Monday"); Day_list.Add("Tuesday"); Day_list.Add("Wednesday");
            Day_list.Add("Thursday"); Day_list.Add("Friday"); Day_list.Add("Saturday");
            Day_list.Add("Sunday");


            ViewBag.S_Time_hh = new SelectList(hh_list);
            ViewBag.S_Time_mm = new SelectList(mm_list);

            ViewBag.E_Time_hh = new SelectList(hh_list);
            ViewBag.E_Time_mm = new SelectList(mm_list);

            ViewBag.Day = new SelectList(Day_list);



            //var DayLst = new List<string>();

            //var DayQry = from d in _db.Allocations
            //                  orderby d.day
            //                  select d.day;

            //DayLst.AddRange(DayQry.Distinct());
            //ViewBag.Day = new SelectList(DayLst);

            var allocations = from m in _db.Allocations
                              select m;


            if (!String.IsNullOrEmpty(C_id) && !String.IsNullOrEmpty(Day))
            {
                allocations = allocations.Where(s => ((s.class_id.Contains(C_id)) && (s.day.Contains(Day))));

            }

            if (!string.IsNullOrEmpty(Day))
            {
                allocations = allocations.Where(x => x.day == Day);
            }



            if (!String.IsNullOrEmpty(S_Time_hh) || !String.IsNullOrEmpty(S_Time_mm))
            {
                String Time_Start = S_Time_hh + ":" + S_Time_mm;

                allocations = allocations.Where(x => x.start_time == Time_Start);
            }

            if (!String.IsNullOrEmpty(E_Time_hh) || !String.IsNullOrEmpty(E_Time_mm))
            {
                String Time_End = E_Time_hh + ":" + E_Time_mm;

                allocations = allocations.Where(x => x.end_time == Time_End);
            }



            if (!String.IsNullOrEmpty(C_id))
            {
                allocations = allocations.Where(s => s.class_id.Contains(C_id));

            }


            //if (!String.IsNullOrEmpty(S_Time))
            //{
            //    allocations = allocations.Where(s => s.start_time.Contains(S_Time));

            //}


            //if (!String.IsNullOrEmpty(E_Time))
            //{
            //    allocations = allocations.Where(s => s.end_time.Contains(E_Time));

            //}



            return View(allocations);


        }



        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]  Allocation AllocationToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Allocations.Add(AllocationToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Allocation/Edit/5
        public ActionResult Edit(int id)
        {

            var allocationToEdit = (from c in _db.Allocations
                                    where c.ca_id == id
                                    select c).First();
            return View(allocationToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Allocation allocationToEdit)
        {
            var originalAllocation = (from c in _db.Allocations
                                      where c.ca_id == allocationToEdit.ca_id
                                      select c).First();

            if (!ModelState.IsValid)
                return View(originalAllocation);

            _db.Entry(originalAllocation).CurrentValues.SetValues(allocationToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Allocation allocation = _db.Allocations.Find(id);


            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {

            Allocation allocation = _db.Allocations.Find(id);

            _db.Allocations.Remove(allocation);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Allocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = _db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }
    }
}
