using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Youandweresort.com.Areas.Admin.Models;
using Youandweresort.com.Models;

namespace Youandweresort.com.Areas.Admin.Controllers
{
    public class GalleryImagesController : Controller
    {
        private YouandweresortcomContext db = new YouandweresortcomContext();

        // GET: Admin/GalleryImages
        public ActionResult Index()
        {
            int id = Convert.ToInt32(ViewBag.GalleryModel_Id);
            return View(db.GalleryImages.Where(t => t.GalleryModel_Id == id).ToList());
        }

        // GET: Admin/GalleryImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryImage galleryImage = db.GalleryImages.Find(id);
            if (galleryImage == null)
            {
                return HttpNotFound();
            }
            return View(galleryImage);
        }

        // GET: Admin/GalleryImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GalleryImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,,GalleryModel_Id,ImageUrl,Type")] GalleryImage galleryImage)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(ViewBag.GalleryModel_Id);
                galleryImage.GalleryModel_Id = id;
                db.GalleryImages.Add(galleryImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galleryImage);
        }

        // GET: Admin/GalleryImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryImage galleryImage = db.GalleryImages.Find(id);
            if (galleryImage == null)
            {
                return HttpNotFound();
            }
            return View(galleryImage);
        }

        // POST: Admin/GalleryImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImageUrl,Type")] GalleryImage galleryImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galleryImage);
        }

        // GET: Admin/GalleryImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryImage galleryImage = db.GalleryImages.Find(id);
            if (galleryImage == null)
            {
                return HttpNotFound();
            }
            return View(galleryImage);
        }

        // POST: Admin/GalleryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryImage galleryImage = db.GalleryImages.Find(id);
            db.GalleryImages.Remove(galleryImage);
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
