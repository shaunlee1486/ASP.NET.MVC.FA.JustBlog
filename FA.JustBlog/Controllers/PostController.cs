using FA.JustBlog.Core.JustBlogDbContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        PostRepository post = new PostRepository();
        JustBlogContext db = new JustBlogContext();
        // GET: Post
        public ActionResult Index()
        {
            return View(post.GetAllPosts());
        }

        public ActionResult Details(int id)
        {
            return View(post.FindById(id));
        }

        public ActionResult Create()
        {
            ViewBag.ListCate = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            var post = db.Posts.Find(id);
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}