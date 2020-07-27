using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AleynaBlog.Models;

namespace AleynaBlog.Controllers
{
    using Models;
    using System.IO;
    using System.Web.Helpers;
    public class ContactController : Controller
    {
        // GET: Contact
       
       
        MyBlogEntities db = new MyBlogEntities();
        public ActionResult Index()
        {
            var model = db.Contact.ToList();
            ViewBag.Title = "Iletisim";
            return View(model);
        }
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(Contact contact)
        {
            var contactExist = db.Contact.Any(m => m.Message == contact.Message);
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}