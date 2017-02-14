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
    public class LayoutModelsController : Controller
    {
        private YouandweresortcomContext db = new YouandweresortcomContext();

        // GET: Admin/LayoutModels
        public ActionResult Index()
        {
            return View(db.LayoutModels.ToList());
        }

        // GET: Admin/LayoutModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutModel layoutModel = db.LayoutModels.Find(id);
            if (layoutModel == null)
            {
                return HttpNotFound();
            }
            return View(layoutModel);
        }

        // GET: Admin/LayoutModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LayoutModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Phone,Fax,Email,Longtitude,Lattitude,Header_VN,Header_EN")] LayoutModel layoutModel)
        {
            if (ModelState.IsValid)
            {
                db.LayoutModels.Add(layoutModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(layoutModel);
        }

        // GET: Admin/LayoutModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutModel layoutModel = db.LayoutModels.Find(id);
            if (layoutModel == null)
            {
                return HttpNotFound();
            }
            return View(layoutModel);
        }

        // POST: Admin/LayoutModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Phone,Fax,Email,Longtitude,Lattitude,Header_VN,Header_EN")] LayoutModel layoutModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(layoutModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(layoutModel);
        }

        // GET: Admin/LayoutModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutModel layoutModel = db.LayoutModels.Find(id);
            if (layoutModel == null)
            {
                return HttpNotFound();
            }
            return View(layoutModel);
        }

        // POST: Admin/LayoutModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LayoutModel layoutModel = db.LayoutModels.Find(id);
            db.LayoutModels.Remove(layoutModel);
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
