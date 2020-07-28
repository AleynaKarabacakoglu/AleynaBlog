using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AleynaBlog.Models;

namespace AleynaBlog.Controllers
{
    using Models;
    public class BlogController : Controller
    {
        MyBlogEntities db = new MyBlogEntities();
        // GET: Blog
        public ActionResult Index()
        {
            ViewBag.Title = "Blog";
            return View();
        }
        public ActionResult Category()
        {
            List<Category> kategoriler = db.Category.ToList();
            ViewBag.kategorilerim = kategoriler;
            return View();
        }

        public ActionResult Populer()
        {

            return View();
        }

        public ActionResult Tag()
        {
            List<Tag> etiketler = db.Tag.ToList();
            ViewBag.etiketlerim = etiketler;
            return View();
        }
        public ActionResult Detail()
        {

            return View();
        }

        //public String Listele()
        //{   
        //    //Linq methodları ile veri listeleme
        //    string sonuc = "";
        //    List<Tag> etiketler = db.Tag.ToList();
        //    foreach (Tag tag in etiketler)
        //    {
        //        sonuc += "</br>"+tag.Name;
        //    }
        //    return sonuc;
        //}
        //public String KategoriListele()
        //{
        //    //Linq methodları ile veri listeleme
        //    string sonuc = "";
        //    List<Category> kategoriler = db.Category.ToList();
        //    foreach (Category kategori in kategoriler)
        //    {
        //        sonuc += "</br>" + kategori.Name;
        //    }
        //    return sonuc;
        //}
    }
}
