using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class AttendanceController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Attendance
        public ActionResult Attendance()
        {
            var studentAttend = from std in _db.student_attendence select std;
            var stds = from std in _db.student_attendence orderby std.date where std.date == DateTime.Today select std;
            return View(stds);
        }

        // GET: EmployeeAttendance/Create
        public ActionResult Create()
        {
            student_attendence empModel = new student_attendence();

            empModel.studentCollection = _db.Students.ToList<Student>();

            return View(empModel);
        }

        // POST: EmployeeAttendance/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "att_id")] student_attendence studentToAttend)
        {

            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.student_attendence.Add(studentToAttend);
                _db.SaveChanges();

                return RedirectToAction("Attendance");
                
            }
            catch
            {
                return View();
            }


        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Attendance/Delete/5
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

    }
}