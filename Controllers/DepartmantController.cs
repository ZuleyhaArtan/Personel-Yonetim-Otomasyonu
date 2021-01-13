using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using deneme2.Models;

namespace deneme2.Controllers
{
    [_SessionControl]
    public class DepartmantController : Controller
    {
        private UserManagementEF db = new UserManagementEF();

        // GET: Departmant
        public ActionResult Index()
        {
            return View(db.Departmant.ToList());
        }

        // GET: Departmant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmant departmant = db.Departmant.Find(id);
            if (departmant == null)
            {
                return HttpNotFound();
            }
            return View(departmant);
        }

        // GET: Departmant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departmant/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,departmantName")] Departmant departmant)
        {
            if (ModelState.IsValid)
           {
                departmant.createDate = DateTime.Now;
                db.Departmant.Add(departmant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmant);
        }

        // GET: Departmant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmant departmant = db.Departmant.Find(id);
            if (departmant == null)
            {
                return HttpNotFound();
            }
            return View(departmant);
        }

        // POST: Departmant/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,createDate,departmantName")] Departmant departmant)
        {
            if (ModelState.IsValid)
            {
                departmant.createDate = DateTime.Now;
                db.Entry(departmant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmant);
        }

        // GET: Departmant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmant departmant = db.Departmant.Find(id);
            if (departmant == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Departmant.Remove(departmant);
                db.SaveChanges();
            }
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
