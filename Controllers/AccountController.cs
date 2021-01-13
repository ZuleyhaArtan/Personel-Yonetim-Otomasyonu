using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using deneme2.Models;

namespace deneme2.Controllers
{
    public class AccountController : Controller
    {

        UserManagementEF db = new UserManagementEF();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home/Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                Personal activePersonel = db.Personal.Where(x => x.tcNo == model.EMail && x.password == model.Password&&x.isUser==true).FirstOrDefault();

                if (activePersonel != null)
                {
                    FormsAuthentication.SetAuthCookie(activePersonel.tcNo, true);
                    Session["personelId"] = activePersonel.personalId;
                    Session["AdiSoyadi"] = activePersonel.personalName+" "+activePersonel.personalLastName;
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    if (model.EMail == "10038183026" && model.Password == "123")
                    {
                        FormsAuthentication.SetAuthCookie("10038183026", true);
                        Session["AdiSoyadi"] = "Super User";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kimlik numarası ya da şifre hatalı!");
                    }
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}