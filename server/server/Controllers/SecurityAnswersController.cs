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
    public class SecurityAnswersController : Controller
    {
        private UserDataContext db = new UserDataContext();

        // GET: SecurityAnswers
        public ActionResult Index()
        {
            var securityAnswers = db.SecurityAnswers.Include(s => s.SecurityQuestion).Include(s => s.User);
            return View(securityAnswers.ToList());
        }

        // GET: SecurityAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityAnswer securityAnswer = db.SecurityAnswers.Find(id);
            if (securityAnswer == null)
            {
                return HttpNotFound();
            }
            return View(securityAnswer);
        }

        // GET: SecurityAnswers/Create
        public ActionResult Create()
        {
            ViewBag.SecurityQuestionID = new SelectList(db.SecurityQuestions, "SecurityQuestionID", "Question");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email");
            return View();
        }

        // POST: SecurityAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecurityAnswerID,UserID,SecurityQuestionID,Answer")] SecurityAnswer securityAnswer)
        {
            if (ModelState.IsValid)
            {
                db.SecurityAnswers.Add(securityAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SecurityQuestionID = new SelectList(db.SecurityQuestions, "SecurityQuestionID", "Question", securityAnswer.SecurityQuestionID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email", securityAnswer.UserID);
            return View(securityAnswer);
        }

        // GET: SecurityAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityAnswer securityAnswer = db.SecurityAnswers.Find(id);
            if (securityAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SecurityQuestionID = new SelectList(db.SecurityQuestions, "SecurityQuestionID", "Question", securityAnswer.SecurityQuestionID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email", securityAnswer.UserID);
            return View(securityAnswer);
        }

        // POST: SecurityAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecurityAnswerID,UserID,SecurityQuestionID,Answer")] SecurityAnswer securityAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SecurityQuestionID = new SelectList(db.SecurityQuestions, "SecurityQuestionID", "Question", securityAnswer.SecurityQuestionID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "Email", securityAnswer.UserID);
            return View(securityAnswer);
        }

        // GET: SecurityAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityAnswer securityAnswer = db.SecurityAnswers.Find(id);
            if (securityAnswer == null)
            {
                return HttpNotFound();
            }
            return View(securityAnswer);
        }

        // POST: SecurityAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityAnswer securityAnswer = db.SecurityAnswers.Find(id);
            db.SecurityAnswers.Remove(securityAnswer);
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
