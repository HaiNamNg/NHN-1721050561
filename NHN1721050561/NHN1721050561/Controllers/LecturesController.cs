using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHN1721050561.Models;

namespace NHN1721050561.Controllers
{
    public class LecturesController : Controller
    {
        private BaiTapDBcontext db = new BaiTapDBcontext();
        StringProcess strPro = new StringProcess();

        // GET: Lectures
        public ActionResult Index()
        {
            return View(db.Lectures.ToList());
        }

        // GET: Lectures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: Lectures/Create
        public ActionResult Create()
        {
            if (db.Lectures.OrderByDescending(m => m.PersonID).Count() == 0)
            {
                var newID = "LCT002";
                ViewBag.newid = newID;
            }
            else
            {
                var PsID = db.Lectures.OrderByDescending(m => m.PersonID).FirstOrDefault().PersonID;
                var newID = strPro.GenerateKey("LCT", PsID);
                ViewBag.newid = newID;
            }
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,PersonName,Faculty,Department")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(lecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,PersonName,Faculty,Department")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Persons.Remove(lecture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
