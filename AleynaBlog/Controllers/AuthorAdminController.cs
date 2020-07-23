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
    }
}