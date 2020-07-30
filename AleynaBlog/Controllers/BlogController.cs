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

    public class BlogController : Controller
    {
        MyBlogEntities db = new MyBlogEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Blog";
            var model = db.Article.ToList();           
            return View(model);
            
        }
        public ActionResult Category()
        {
            List<Category> kategoriler = db.Category.ToList();
            ViewBag.kategorilerim = kategoriler;
            return View();
        }

        public ActionResult Detail()
        {
            List<Article> makaleler = db.Article.ToList();
            ViewBag.makalelerim = makaleler;
            return View();
        }

        public ActionResult Article()
        {
            List<Article> makaleler = db.Article.ToList();
            ViewBag.makalelerim = makaleler;
            return View();
        }

        public ActionResult Tag()
        {
            List<Tag> etiketler = db.Tag.ToList();
            ViewBag.etiketlerim = etiketler;
            return View();
        }
        public ActionResult Populer()
        {
            List<Article> makaleler = db.Article.ToList();
            ViewBag.makalelerim = makaleler;
            return View();
        }

        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article, HttpPostedFileBase File)
        {
            var articleExist = db.Author.Any(m => m.Id == article.Id);

            if (articleExist == false)
            {
                article.AddedDate = DateTime.Now;
               
                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    img.Resize(225, 180, false, false);
                    string tamyol = "~/images/users/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    article.Image = "/images/users/" + uzanti;
                }
                db.Article.Add(article);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        /*
        public String Listele()
        {
            //Linq methodları ile veri listeleme
            string sonuc = "";
            List<Tag> etiketler = db.Tag.ToList();
            foreach (Tag tag in etiketler)
            {
                sonuc += "</br>" + tag.Name;
            }
            return sonuc;
        }
        public String KategoriListele()
        {
            //Linq methodları ile veri listeleme
            string sonuc = "";
            List<Category> kategoriler = db.Category.ToList();
            foreach (Category kategori in kategoriler)
            {
                sonuc += "</br>" + kategori.Name;
            }
            return sonuc;
        }*/
    }
}
