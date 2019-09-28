using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class FinanceManagerController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: FinanceManager
        public ActionResult FinanceManagerHome()
        {
            return View();
        }


        // GET: Students/Delete/5
        public ActionResult DeleteInvoice(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Invoices");
            }
            Invoice invoiceToDelete = _db.Invoices.Find(id);
            if (invoiceToDelete == null)
            {
                return HttpNotFound();
            }
            return View(invoiceToDelete);


        }


        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteInvoice")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInvoice(int id)
        {
            Invoice invoiceToDelete = _db.Invoices.Find(id);
            _db.Invoices.Remove(invoiceToDelete);
            _db.SaveChanges();
            return RedirectToAction("Invoices");

        }





        public ActionResult Taxes()
        {
            return View(_db.Taxes.ToList());
        }
        public ActionResult EditTax(int id)
        {
            return View();
        }






        public ActionResult EditInvoice(int id)
        {


            return View();
        }


        public ActionResult Invoices()
        {
            ViewBag.Message = "Invoices";
            return View(_db.Invoices.ToList());
        }

        public ActionResult NewInvoice()
        {

            return View();



        }

        public ActionResult NewTax()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }



        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Tax taxes)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Taxes.Add(taxes);
            _db.SaveChanges();

            return RedirectToAction("Taxes");
        }



        public ActionResult Income()
        {

            ViewBag.Message = "Income page";
            return View();
        }

        public ActionResult Expenses()
        {
            ViewBag.Message = "Expense Page";
            return View();
        }

        // GET: FinanceManager/Details/5


        public ActionResult OTOverview()
        {
            return View();
        }


        public ActionResult NewBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBill(Bill bill)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Bills.Add(bill);
            _db.SaveChanges();

            return RedirectToAction("Bill");
        }








        public ActionResult Bill()
        {
            return View(_db.Bills.ToList());
        }

        //GET
        public ActionResult EditBill(int id)
        {
            var billToEdit = (from m in _db.Bills
                              where m.billId == id
                              select m).First();
            return View(billToEdit);

            //return View();
        }

        [HttpPost]
        public ActionResult EditBill(Bill billToEdit)
        {
            var originalBill = (from m in _db.Bills
                                where m.billId == billToEdit.billId
                                select m).First();

            if (!ModelState.IsValid)
                return View(originalBill);

            _db.Entry(originalBill).CurrentValues.SetValues(billToEdit);
            _db.SaveChanges();

            return RedirectToAction("Bill");
        }











    }
}
