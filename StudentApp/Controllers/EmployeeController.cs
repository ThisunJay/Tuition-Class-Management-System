using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Microsoft.Reporting.WebForms;

namespace StudentApp.Controllers
{
    public class EmployeeController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Employee
        public ActionResult EmployeeView(string Search,int? i)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var employees = from em in _db.employees select em;

                if (!String.IsNullOrEmpty(Search))
                {
                    employees = employees.Where(e => e.full_name.Contains(Search));
                }

                return View(employees.ToList().ToPagedList(i ?? 1,10));
            }
            //return View(_db.employees.Where(emp => emp.full_name.Contains(Search) || Search == null).ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employeeDetail = (from m in _db.employees
                                  where m.emp_id == id
                                  select m).First();
            return View(employeeDetail);
            //return View();
        }

        // GET: Employee/Create
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

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "emp_id")] employee employeeToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.employees.Add(employeeToCreate);
                _db.SaveChanges();

                return RedirectToAction("EmployeeView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employeeToEdit = (from m in _db.employees
                                  where m.emp_id == id
                                  select m).First();
            return View(employeeToEdit);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(employee employeeToEdit)
        {
            try
            {
                var originalEmployee = (from m in _db.employees
                                        where m.emp_id == employeeToEdit.emp_id
                                        select m).First();

                if (!ModelState.IsValid)
                    return View(originalEmployee);

                _db.Entry(originalEmployee).CurrentValues.SetValues(employeeToEdit);
                _db.SaveChanges();

                return RedirectToAction("EmployeeView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee em = _db.employees.Find(id);
            if (em == null)
            {
                return HttpNotFound();
            }
            return View(em);
        }

        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee em = _db.employees.Find(id);
            _db.employees.Remove(em);
            _db.SaveChanges();
            return RedirectToAction("EmployeeView");
        }

        //GET: /Employee/AttendanceEnter/3
        public ActionResult AttendanceEnter(int id)
        {
            var employeeToAttend = (from em in _db.emp_attendence
                                    where em.emp_id == id
                                    select em).First();

            return View(employeeToAttend);
        }

        public ActionResult AttendanceEnter(employee employeeToAttend)
        {

            return View();
        }

        public ActionResult main() {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Reports(String ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/EmployeeReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "EmployeeDataSet";
            reportDataSource.Value = _db.employees.ToList();
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
            Response.AddHeader("content-disposition", "attachment:filename= emp_att_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }

    }
}
