using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoreCrud.DAL;
using CoreCrud.Models;

namespace CoreCrud.Controllers
{
    public class CollectibleController : Controller
    {
        private ManuContext db = new ManuContext();

        // GET: Collectible
        public ActionResult Index()
        {
            return View(db.Collectibles.ToList());
        }

        // GET: Collectible/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectible collectible = db.Collectibles.Find(id);
            if (collectible == null)
            {
                return HttpNotFound();
            }
            return View(collectible);
        }

        // GET: Collectible/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collectible/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CreationDate,Weight,Electronic,Material")] Collectible collectible)
        {
            if (ModelState.IsValid)
            {
                db.Collectibles.Add(collectible);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collectible);
        }

        // GET: Collectible/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectible collectible = db.Collectibles.Find(id);
            if (collectible == null)
            {
                return HttpNotFound();
            }
            return View(collectible);
        }

        // POST: Collectible/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CreationDate,Weight,Electronic,Material")] Collectible collectible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collectible);
        }

        // GET: Collectible/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectible collectible = db.Collectibles.Find(id);
            if (collectible == null)
            {
                return HttpNotFound();
            }
            return View(collectible);
        }

        // POST: Collectible/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collectible collectible = db.Collectibles.Find(id);
            db.Collectibles.Remove(collectible);
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
