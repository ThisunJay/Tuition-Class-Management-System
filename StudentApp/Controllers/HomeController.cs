
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "All the Events";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude ="id")] Student studentToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Students.Add(studentToCreate);
            _db.SaveChanges();

            return RedirectToAction("signup");
        }

        //signup page fro student
        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup([Bind(Exclude = "id")] user signupcreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.users.Add(signupcreate);
            _db.SaveChanges();

            return RedirectToAction("loginUser");
        }


        public ActionResult loginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginUser(user u)
        {
            if (!ModelState.IsValid)
                return View();

            var user = _db.users.Where(model => model.UserName_ == u.UserName_ && model.Password_ == u.Password_).FirstOrDefault();
            if (user.UserName_ == "admin@gmail.com" && user.Password_ == "admin123")
            {
                Session["UserID"] = u.UserId_.ToString();
                Session["UserName"] = u.UserName_.ToString();
                return RedirectToAction("../Admin/AdminView");
            }
            else if (user != null)
            {
                Session["UserId"] = u.UserId_.ToString();
                Session["Username"] = u.UserName_.ToString();
                TempData["LoginSuccessmessage"] = "<script>alert('Successfully Login')</script>";
                return RedirectToAction("StudentProfile", "StudentProfile");
            }   
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Login Failed ')</script>";
                return View();
            }

        }





        //login function starts here
        /*
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objUser)
        {
            if (ModelState.IsValid)
            {
                using (TCMSDBEntities db = new TCMSDBEntities())
                {
                    var obj = db.users.Where(a => a.UserName_.Equals(objUser.UserName_) && a.Password_.Equals(objUser.Password_)).FirstOrDefault();
                    if (obj != null)
                    {
                        if (obj.UserName_ == "Ozandabb" && obj.Password_ == "osanda123")
                        {
                            Session["UserID"] = obj.UserId_.ToString();
                            Session["UserName"] = obj.UserName_.ToString();
                            return RedirectToAction("../Admin/AdminView");


                        }
                        else if (obj.UserName_ == "ThisunJay" && obj.Password_ == "thisun123")
                        {
                            Session["UserID"] = obj.UserId_.ToString();
                            Session["UserName"] = obj.UserName_.ToString();
                            return RedirectToAction("../Employee/EmployeeView");
                        }
                        else
                        {
                            Session["UserID"] = obj.UserId_.ToString();
                            Session["UserName"] = obj.UserName_.ToString();
                            return RedirectToAction("../StudentProfile/StudentProfile");

                        }
                    }
                    else
                    {
                        return RedirectToAction("../Views/Login/Login");

                    }
                        
                }
            }
            
            

            return View(objUser);
        }
        */
        //login function ends here



    }
}