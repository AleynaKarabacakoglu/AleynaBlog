using AleynaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AleynaBlog.Controllers
{
    using Models;
    public class AuthorAdminController : Controller
    {
        // GET: Author

        MyBlogEntities db = new MyBlogEntities();
        public ActionResult Index()
        {
            var model = db.Author.ToList();
            return View(model);
        }
        public ActionResult Delete(int? Id) //"int?" null dönerse hata vermesin diye bu şekilde yazdim.
        {
            if(Id==null)
            {
                return HttpNotFound();
            }
            else
            {
                Author author = db.Author.Find(Id);
                db.Author.Remove(author);
                db.SaveChanges();
                return RedirectToAction("Index"); //Index sayfasına geri döndürüldü.
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}