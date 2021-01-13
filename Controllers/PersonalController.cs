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
    public class PersonalController : Controller
    {
        private UserManagementEF db = new UserManagementEF();

        // GET: Personal
        public ActionResult Index()
        {
            var personal = db.Personal.Include(p => p.City).Include(p => p.Departmant);
            return View(personal.ToList());
        }

        // GET: Personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            ViewBag.cityId = new SelectList(db.City, "id", "cityName");
            ViewBag.departmantId = new SelectList(db.Departmant, "Id", "departmantName");
            return View();
        }

        // POST: Personal/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personalId,createDate,personalName,personalLastName,tcNo,dateOfBirth,workStartTime,cityId,gender,departmantId,password,isUser")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                personal.createDate = DateTime.Now;

                db.Personal.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cityId = new SelectList(db.City, "id", "cityName", personal.cityId);
            ViewBag.departmantId = new SelectList(db.Departmant, "Id", "departmantName", personal.departmantId);
            return View(personal);
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.cityId = new SelectList(db.City, "id", "cityName", personal.cityId);
            ViewBag.departmantId = new SelectList(db.Departmant, "Id", "departmantName", personal.departmantId);
            return View(personal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personalId,personalName,personalLastName,tcNo,dateOfBirth,workStartTime,cityId,gender,departmantId,password,isUser")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                personal.createDate = DateTime.Now;
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cityId = new SelectList(db.City, "id", "cityName", personal.cityId);
            ViewBag.departmantId = new SelectList(db.Departmant, "Id", "departmantName", personal.departmantId);
            return View(personal);
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Personal.Remove(personal);
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
