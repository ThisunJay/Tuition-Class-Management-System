using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Microsoft.Reporting.WebForms;

namespace StudentApp.Controllers
{
    public class TeacherController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();
        // GET: Teacher
        public ActionResult TeacherView(string searching,int? i)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(_db.teachers.Where(x => x.full_name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1,10));

            }
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var teacherDetais = (from m in _db.teachers
                                 where m.t_id == id
                                 select m).First();
            return View(teacherDetais);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] teacher teacherToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.teachers.Add(teacherToCreate);
            try
            {
                _db.SaveChanges();
            }
            catch
            {

                Console.WriteLine();
            }


            return RedirectToAction("TeacherView");
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var teacherToEdit = (from m in _db.teachers
                                 where m.t_id == id
                                 select m).First();
            return View(teacherToEdit);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(teacher teacherToEdit)
        {
            try
            {
                var originalTeacher = (from m in _db.teachers
                                       where m.t_id == teacherToEdit.t_id
                                       select m).First();

                if (!ModelState.IsValid)
                    return View(originalTeacher);

                _db.Entry(originalTeacher).CurrentValues.SetValues(teacherToEdit);
                _db.SaveChanges();

                return RedirectToAction("TeacherView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("TeacherView");
            }
            teacher teacherToDelete = _db.teachers.Find(id);
            if (teacherToDelete == null)
            {
                return HttpNotFound();
            }
            return View(teacherToDelete);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            teacher teacherToDelete = _db.teachers.Find(id);
            _db.teachers.Remove(teacherToDelete);
            _db.SaveChanges();
            return RedirectToAction("TeacherView");


        }

        public ActionResult paymentAdd(int id)
        {

            var teacherToEdit = (from m in _db.teachers
                                 where m.t_id == id
                                 select m).First();
            return View(teacherToEdit);
        }

        //POST: Teacher/
        [HttpPost]
        public ActionResult paymentAdd(teacher tpay)
        {
            try
            {
                var originalTeacher = (from m in _db.teachers
                                       where m.t_id == tpay.t_id
                                       select m).First();

                if (!ModelState.IsValid)
                    return View(originalTeacher);

                _db.Entry(originalTeacher).CurrentValues.SetValues(tpay);
                _db.SaveChanges();

                return RedirectToAction("TeacherView");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Reports(String ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/TeachersReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "TeachersDataSet";
            reportDataSource.Value = _db.teachers.ToList();
            localReport.DataSources.Add(reportDataSource);
            String reportType = ReportType;
            String mimeType;
            String encoding;
            String fileNameExtension;

            if (reportType == "PDF")
            {
                fileNameExtension = "PDF";
            }
            else if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= teachers_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }
    }
}
