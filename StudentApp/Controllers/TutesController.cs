using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentApp.Controllers
{
    public class TutesController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Tutes1.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var tuteDetails = (from m in _db.Tutes1
                                 where m.Tute_id == id
                                 select m).First();
            return View(tuteDetails);
            //return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Tutes tuteToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _db.Tutes1.Add(tuteToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }


        // GET: Home/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tuteToEdit = (from m in _db.Tutes1
                              where m.Tute_id == id
                              select m).First();
            return View(tuteToEdit);
        }

        // POST: Home/Edit/5 
        [HttpPost]
        public ActionResult Edit(Tutes tuteToEdit)
        {
            var originalTute = (from m in _db.Tutes1
                                where m.Tute_id == tuteToEdit.Tute_id
                                select m).First();
            if (!ModelState.IsValid)
                return View(originalTute);

            _db.Entry(originalTute).CurrentValues.SetValues(tuteToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }

        // GET: Tutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Tutes tuteToDelete = _db.Tutes1.Find(id);
            if (tuteToDelete == null)
            {
                return HttpNotFound();
            }
            return View(tuteToDelete);


        }


        // POST: Tutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Tutes tuteToDelete = _db.Tutes1.Find(id);
            _db.Tutes1.Remove(tuteToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}