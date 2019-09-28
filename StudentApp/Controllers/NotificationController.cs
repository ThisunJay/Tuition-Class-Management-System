using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class NotificationController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();
        // GET: Notification
        public ActionResult Index(string Search)
        {
            var noti = from no in _db.notifies select no;

            if (!String.IsNullOrEmpty(Search))
            {
                noti = noti.Where(e => e.title.Contains(Search));
            }

            return View(noti);
        }

        public ActionResult StuNotifyView(string Search)
        {
            var noti = from no in _db.notifies select no;

            if (!String.IsNullOrEmpty(Search))
            {
                noti = noti.Where(e => e.title.Contains(Search));
            }

            return View(noti);
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "emp_id")] notify notifyToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.notifies.Add(notifyToCreate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(int id)
        {
            var notifyToEdit = (from m in _db.notifies
                                  where m.n_id == id
                                  select m).First();
            return View(notifyToEdit);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        public ActionResult Edit(notify notifyToEdit)
        {
            try
            {
                var originalNotify = (from m in _db.notifies
                                        where m.n_id == notifyToEdit.n_id
                                        select m).First();

                if (!ModelState.IsValid)
                    return View(originalNotify);

                _db.Entry(originalNotify).CurrentValues.SetValues(notifyToEdit);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notify no = _db.notifies.Find(id);
            if (no == null)
            {
                return HttpNotFound();
            }
            return View(no);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            notify no = _db.notifies.Find(id);
            _db.notifies.Remove(no);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
