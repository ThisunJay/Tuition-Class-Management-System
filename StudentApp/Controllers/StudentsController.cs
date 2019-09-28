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
    public class StudentsController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();


        // GET: Students
        public ActionResult StudentView(string searching,int? i)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(_db.Students.Where(x => x.Full_Name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 10));
            }
        }
        
        public ActionResult Details(int id)
        {
               var studentDetais = (from m in _db.Students
                                     where m.Id == id
                                     select m).First();
                return View(studentDetais);
            
            
        }


        // GET: Students/Create
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        // POST: Students/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Student studentToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Students.Add(studentToCreate);
            _db.SaveChanges();

            return RedirectToAction("StudentView");
        }


        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var studentToEdit = (from m in _db.Students
                                 where m.Id == id
                                 select m).First();
            return View(studentToEdit);
        }


        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(Student studentToEdit)
        {
            var originalStudent = (from m in _db.Students
                                   where m.Id == studentToEdit.Id
                                   select m).First();

            if (!ModelState.IsValid)
                return View(originalStudent);

            _db.Entry(originalStudent).CurrentValues.SetValues(studentToEdit);
            _db.SaveChanges();

            return RedirectToAction("StudentView");
        }


        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("StudentView");
            }
            Student studentToDelete = _db.Students.Find(id);
            if (studentToDelete == null)
            {
                return HttpNotFound();
            }
            return View(studentToDelete);


        }


        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id )
        {
            Student studentToDelete = _db.Students.Find(id);
            _db.Students.Remove(studentToDelete);
            _db.SaveChanges();
            return RedirectToAction("StudentView");

        }


        //To get an entrance to attandance page
        public ActionResult Attendance()
        {
            return RedirectToAction("../Attendance/Create");
        }


        //Filter option to filter by school and the division
        public ActionResult filterBy(string schl , string division)
        {
            ViewBag.School = (from r in _db.Students
                              select r.School).Distinct();

            ViewBag.Division = (from r in _db.Students
                                select r.Division).Distinct();

            var model = from r in _db.Students
                        orderby r.Full_Name
                        where r.School == schl || schl == null || schl == ""
                        where r.Division == division
                        select r;
                


            return View(model);
        }

        public ActionResult Reports(String ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/StudentsReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "StudentDataSet";
            reportDataSource.Value = _db.Students.ToList();
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
            Response.AddHeader("content-disposition", "attachment:filename= studentsRep." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }


        public ActionResult generate()
        {
            return View("generate");
        }

    }
}
