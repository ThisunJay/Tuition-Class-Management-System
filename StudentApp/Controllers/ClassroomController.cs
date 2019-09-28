using Microsoft.Reporting.WebForms;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace TMSApp.Controllers
{
    public class classroomController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();
        // GET: classroom



        public ActionResult Index(string Location, string C_Name, string F_Name, string AcNon)
        {
            var LocationLst = new List<string>();

            var LocationQry = from d in _db.classrooms
                              orderby d.location
                              select d.location;

            LocationLst.AddRange(LocationQry.Distinct());
            ViewBag.Location = new SelectList(LocationLst);

            var classroom = from m in _db.classrooms
                            select m;

            if (!String.IsNullOrEmpty(C_Name))
            {
                classroom = classroom.Where(s => s.name.Contains(C_Name));
            }
            if (!String.IsNullOrEmpty(F_Name))
            {
                classroom = classroom.Where(s => s.name.Contains(F_Name));
            }

            if (!string.IsNullOrEmpty(Location))
            {
                classroom = classroom.Where(x => x.location == Location);
            }

            if (!String.IsNullOrEmpty(AcNon))
            {
                classroom = classroom.Where(s => s.ac_nonac.Contains(AcNon));
            }

            return View(classroom);
        }

        [HttpPost]
        public string Index(FormCollection fc, string location)
        {
            return "<h3> From [HttpPost]Index: " + location + "</h3>";
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create


        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]  classroom classroomToCreate)
        {


            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.classrooms.Add(classroomToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {

            var classroomToEdit = (from c in _db.classrooms
                                   where c.class_id == id
                                   select c).First();
            return View(classroomToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(classroom classroomToEdit)
        {
            var originalclassroom = (from c in _db.classrooms
                                     where c.class_id == classroomToEdit.class_id
                                     select c).First();

            if (!ModelState.IsValid)
                return View(originalclassroom);

            _db.Entry(originalclassroom).CurrentValues.SetValues(classroomToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            classroom classroom = _db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {

            classroom classroom = _db.classrooms.Find(id);

            _db.classrooms.Remove(classroom);
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
            classroom classroom = _db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }
        // GET: Allocation/view2/18
        public ActionResult view2(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            classroom classroom = _db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: Allocation/view3/5
        public ActionResult view3(int? id)
        {
            if (id == null)
            {
                id = 2;
            }
            classroom classroom = _db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        public ActionResult Reports(String ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/ClassRoomReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "ClassRoomDataSet";
            reportDataSource.Value = _db.classrooms.ToList();
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
            Response.AddHeader("content-disposition", "attachment:filename= classRoom_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }
    }
}
