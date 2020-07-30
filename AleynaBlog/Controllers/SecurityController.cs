using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AleynaBlog.Models;
using System.Web.Security;
namespace AleynaBlog.Controllers
{
    public class SecurityController : Controller
    {
        MyBlogEntities db = new MyBlogEntities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Author admin)
        {
            var bilgiler = db.Author.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                //Session["Email"] = bilgiler;
                return RedirectToAction("Index", "AuthorAdmin");
            }
            else
            {
                ViewBag.error = "Geçersiz Mail veya şifre";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}