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
    public class GalleryModelsController : Controller
    {
        private YouandweresortcomContext db = new YouandweresortcomContext();

        // GET: Admin/GalleryModels
        public ActionResult Index()
        {
            return View(db.GalleryModels.ToList());
        }

        // GET: Admin/GalleryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryModel galleryModel = db.GalleryModels.Find(id);
            if (galleryModel == null)
            {
                return HttpNotFound();
            }
            return View(galleryModel);
        }

        // GET: Admin/GalleryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GalleryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Gallery_VN,Gallery_EN")] GalleryModel galleryModel)
        {
            if (ModelState.IsValid)
            {
                db.GalleryModels.Add(galleryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galleryModel);
        }

        // GET: Admin/GalleryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryModel galleryModel = db.GalleryModels.Find(id);
            if (galleryModel == null)
            {
                return HttpNotFound();
            }
            return View(galleryModel);
        }

        // POST: Admin/GalleryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gallery_VN,Gallery_EN")] GalleryModel galleryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galleryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galleryModel);
        }

        // GET: Admin/GalleryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryModel galleryModel = db.GalleryModels.Find(id);
            if (galleryModel == null)
            {
                return HttpNotFound();
            }
            return View(galleryModel);
        }

        // POST: Admin/GalleryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GalleryModel galleryModel = db.GalleryModels.Find(id);
            db.GalleryModels.Remove(galleryModel);
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
