using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Whatfits.Models;
using Whatfits.Models.Context;

namespace server.Controllers
{
    public class PersonalKeysController : Controller
    {
        private UserDataContext db = new UserDataContext();

        // GET: PersonalKeys
        public ActionResult Index()
        {
            var personalKeys = db.PersonalKeys.Include(p => p.Credential);
            return View(personalKeys.ToList());
        }

        // GET: PersonalKeys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalKey personalKey = db.PersonalKeys.Find(id);
            if (personalKey == null)
            {
                return HttpNotFound();
            }
            return View(personalKey);
        }

        // GET: PersonalKeys/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Credentials, "UserID", "UserName");
            return View();
        }

        // POST: PersonalKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Salt")] PersonalKey personalKey)
        {
            if (ModelState.IsValid)
            {
                db.PersonalKeys.Add(personalKey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Credentials, "UserID", "UserName", personalKey.UserID);
            return View(personalKey);
        }

        // GET: PersonalKeys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalKey personalKey = db.PersonalKeys.Find(id);
            if (personalKey == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Credentials, "UserID", "UserName", personalKey.UserID);
            return View(personalKey);
        }

        // POST: PersonalKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Salt")] PersonalKey personalKey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalKey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Credentials, "UserID", "UserName", personalKey.UserID);
            return View(personalKey);
        }

        // GET: PersonalKeys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalKey personalKey = db.PersonalKeys.Find(id);
            if (personalKey == null)
            {
                return HttpNotFound();
            }
            return View(personalKey);
        }

        // POST: PersonalKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalKey personalKey = db.PersonalKeys.Find(id);
            db.PersonalKeys.Remove(personalKey);
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
