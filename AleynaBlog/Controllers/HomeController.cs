using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AleynaBlog.Controllers
{
    using Models;
    public class HomeController : Controller
    {

        MyBlogEntities db = new MyBlogEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Benim Bloğum";
            return View();
        }
        public ActionResult Slider()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Counter()
        {
            return View();
        }
        public ActionResult Blog()
        {
            List<Article> articles = db.Article.ToList();
            ViewBag.makalelerim = articles;
            return View();
        }
    }
}