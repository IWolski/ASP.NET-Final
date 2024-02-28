using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;

namespace ASP_Final.Controllers
{
    public class BOOKsController : Controller
    {
        private HenryEntities db = new HenryEntities();

        // GET: BOOKs
        public ActionResult Index()
        {
            var bOOK = db.BOOK.Include(b => b.PUBLISHER).Include(b => b.PUBLISHER1).Include(b => b.PUBLISHER2);
            return View(bOOK.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME");
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME");
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME");
            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_CODE,TITLE,PUBLISHER_CODE,TYPE,PRICE,PAPERBACK")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOK.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_CODE,TITLE,PUBLISHER_CODE,TYPE,PRICE,PAPERBACK")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHER, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOK.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BOOK bOOK = db.BOOK.Find(id);
            db.BOOK.Remove(bOOK);
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
