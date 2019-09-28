using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace StudentApp.Controllers
{
    public class ExamController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Exam
        public ActionResult Exams(int? i)
        {
            var exam = from ex in _db.exams select ex;
            return View(exam.ToList().ToPagedList(i ?? 1,10));
        }

        // GET: Exam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] exam examsToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.exams.Add(examsToCreate);
            _db.SaveChanges();

            return RedirectToAction("Exams");
        }

        // GET: Exam/Edit/5
        public ActionResult Edit(int id)
        {
            var examsToEdit = (from m in _db.exams
                               where m.exam_id == id
                               select m).First();
            return View(examsToEdit);
        }

        // POST: Exam/Edit/5
        [HttpPost]
        public ActionResult Edit(exam examToEdit)
        {
            var originalExam = (from m in _db.exams
                                where m.exam_id == examToEdit.exam_id
                                select m).First();

            if (!ModelState.IsValid)
                return View(originalExam);

            _db.Entry(originalExam).CurrentValues.SetValues(examToEdit);
            _db.SaveChanges();

            return RedirectToAction("Exams");
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Exams");
            }
            exam examsToDelete = _db.exams.Find(id);
            if (examsToDelete == null)
            {
                return HttpNotFound();
            }
            return View(examsToDelete);
           
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            exam examsToDelete = _db.exams.Find(id);
            _db.exams.Remove(examsToDelete);
            _db.SaveChanges();
            return RedirectToAction("Exams");
        }
    }
}
