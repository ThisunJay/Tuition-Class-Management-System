using Microsoft.Reporting.WebForms;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: EmployeeAttendance
        public ActionResult Index()
        {
            var employeeAttend = from emp in _db.emp_attendence select emp;

            //employees = employees.Where(e => e.full_name.Contains(Search));.
            //employeeAttend = employeeAttend.Where(e => e.date.ToString().Contains(DateTime.Today.ToString()));

            //ViewBag.toDate = (from empp in _db.emp_attendence select empp.emp_id).Distinct();

            var emps = from emp in _db.emp_attendence orderby emp.date where emp.date == DateTime.Today select emp;

            return View(emps);
        }

        // GET: EmployeeAttendance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeAttendance/Create
        public ActionResult Create()
        {
            emp_attendence empModel = new emp_attendence();

            empModel.employeeCollection = _db.employees.ToList<employee>();

            return View(empModel);
        }

        // POST: EmployeeAttendance/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "att_id")] emp_attendence employeeToAttend)
        {
            
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.emp_attendence.Add(employeeToAttend);
                _db.SaveChanges();

                return RedirectToAction("Index");
                //return View();
            }
            catch
            {
                return View();
            }


        }

        public ActionResult AddOrEdit(int id = 0) {

            emp_attendence empModel = new emp_attendence();

            empModel.employeeCollection = _db.employees.ToList<employee>();

            return View(empModel);
        }

        // GET: EmployeeAttendance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeAttendance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAttendance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeAttendance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult seeAttendance(DateTime date)
        //{
        //    var emps = from emp in _db.emp_attendence orderby emp.date where emp.date == date select emp;

        //    return View(emps);
        //}

        //[HttpPost]
        public ActionResult seeAttendance(DateTime? date)
        {
            //ViewBag.toDate = (from r in _db.emp_attendence
            //                  select r.emp_id.ToString()).Distinct();


            var employeeAttend = from emp in _db.emp_attendence select emp;

            if (date != null)
            {
                employeeAttend = employeeAttend.Where(e => e.date == date);
            }

            return View(employeeAttend);

            //return View(model);
        }

        public ActionResult Reports(String ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/EmployeeAttReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "EmployeeAttDataSet";
            reportDataSource.Value = _db.emp_attendence.Where(e => e.date == DateTime.Today).ToList();
            localReport.DataSources.Add(reportDataSource);
            String reportType = ReportType;
            String mimeType;
            String encoding;
            String fileNameExtension;

            if (reportType == "PDF") {
                fileNameExtension = "PDF";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension,
                out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment:filename= emp_att_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }
    }
}
