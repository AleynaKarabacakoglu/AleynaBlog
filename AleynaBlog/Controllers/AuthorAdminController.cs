using AleynaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AleynaBlog.Controllers
{
    using Models;
    using System.IO;
    using System.Web.Helpers;

    public class AuthorAdminController : Controller
    {

        MyBlogEntities db = new MyBlogEntities();
        public ActionResult Index()
        {
            var model = db.Author.ToList();
            return View(model);
        }
        public ActionResult Delete(int? Id) //"int?" null donerse hata vermemesi icin bu şekilde yazdim.
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
                return RedirectToAction("Index"); //Index sayfasına geri donduruldü.
            }
        }

        //GET için create methodu
        public ActionResult Create()
        {
            return View();
        }


        //Post için create methodu-----
            [HttpPost]
        public ActionResult Create(Author author, HttpPostedFileBase File)
        {
            var authorExist = db.Author.Any(m => m.Email == author.Email);

            if (authorExist == false)
            {
                author.AddedDate = DateTime.Now;
                author.AddedBy = "Aleyna";
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    author.Image = "/images/users/" + uzanti;
                }
                db.Author.Add(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(id);
            return PartialView(author);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }
            Author author = db.Author.Find(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult Edit(Author auth,HttpPostedFileBase File)
        {   
            if(auth!=null)
            {
                db.Entry(auth).State = System.Data.Entity.EntityState.Modified; //Entity frameworkte gelen model üzerinde değişiklik yapma hakkı tanır.
                db.Entry(auth).Property(m => m.AddedBy).IsModified = false;
                db.Entry(auth).Property(m => m.AddedDate).IsModified = false;
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    auth.Image = "/images/users/" + uzanti;
                }
                else
                {
                    db.Entry(auth).Property(m => m.Image).IsModified = false;
                }
                auth.ModifyBy = "Aleyna Karabacakoğlu";
                auth.ModifyDate = DateTime.Now;
                
            }
            db.SaveChanges();
            return RedirectToAction("Index", "AuthorAdmin");
        }
        
        
    }
}