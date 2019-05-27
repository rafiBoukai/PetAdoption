using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetAdoption.DataAccessLayer;
using PetAdoption.Models;

namespace PetAdoption.Controllers
{
    public class AdoptionRequestController : Controller
    {
        private WebAppDBContext db = new WebAppDBContext();

        // GET: AdoptionRequest
        public ActionResult Index()
        {
            var adoptionRequests = db.AdoptionRequests.Include(a => a.Pet).Include(a => a.User);
            return View(adoptionRequests.ToList());
        }

        // GET: AdoptionRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionRequest adoptionRequest = db.AdoptionRequests.Find(id);
            if (adoptionRequest == null)
            {
                return HttpNotFound();
            }
            return View(adoptionRequest);
        }

        // GET: AdoptionRequest/Create
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AdoptionRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,PetId,IsOpen,AdaptionDate")] AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                db.AdoptionRequests.Add(adoptionRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", adoptionRequest.PetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", adoptionRequest.UserId);
            return View(adoptionRequest);
        }

        // GET: AdoptionRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionRequest adoptionRequest = db.AdoptionRequests.Find(id);
            if (adoptionRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", adoptionRequest.PetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", adoptionRequest.UserId);
            return View(adoptionRequest);
        }

        // POST: AdoptionRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,PetId,IsOpen,AdaptionDate")] AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptionRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", adoptionRequest.PetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", adoptionRequest.UserId);
            return View(adoptionRequest);
        }

        // GET: AdoptionRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdoptionRequest adoptionRequest = db.AdoptionRequests.Find(id);
            if (adoptionRequest == null)
            {
                return HttpNotFound();
            }
            return View(adoptionRequest);
        }

        // POST: AdoptionRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdoptionRequest adoptionRequest = db.AdoptionRequests.Find(id);
            db.AdoptionRequests.Remove(adoptionRequest);
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
