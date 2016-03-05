using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDemo.Models;
using System.Collections;

namespace BlogDemo.Controllers
{
    public class PostController : Controller
    {
        private Posts posts;
        private Users users;
        private Comments comments;
        public PostController()
        {
            posts = new Posts();
            users = new Users();
            comments = new Comments();
        }
        public ActionResult Index(int param1 = 0, int param2 = 1)
        {
            int uid = param1;
            int page = param2;
            List<Posts.Post> postList = posts.Index(uid, page);
            ViewData["postList"] = postList;
            int pageNum = posts.GetPageNum(uid);
            ViewData["pageNum"] = pageNum;
            ViewData["uid"] = uid;
            ViewData["page"] = page;
            return View();
        }
        public ActionResult Add()
        {
            if (users.GetState() == 0)
            {
                return Redirect("/User/Login");
            }
            return View();
        }
        public ActionResult Show(int param1 = 1)
        {
            int pid = param1;
            Posts.Post post = posts.Show(pid);
            ViewData["post"] = post;
            List<Comments.Comment> commentList = comments.Index(pid);
            ViewData["commentList"] = commentList;
            return View();
        }
        public ActionResult Modify(int param1)
        {
            int pid = param1;
            Posts.Post post = posts.Show(pid);
            if (users.GetState() != post.uid)
            {
                return Redirect("/User/Login");
            }
            ViewData["post"] = post;
            return View();
        }
        public ActionResult Delete(int param1 = 0)
        {
            int pid = param1;
            Posts.Post post = posts.Show(pid);
            if (users.GetState() != post.uid)
            {
                return Redirect("/User/Login");
            }
            posts.Delete(pid);
            return Redirect("/Post/Manage");
        }
        public ActionResult Manage(int param1 = 0, int param2 = 1)
        {
            if (users.GetState() == 0)
            {
                return Redirect("/User/Login");
            }
            int uid = users.GetState();
            int page = param2;
            List<Posts.Post> postList = posts.Index(uid, page);
            ViewData["postList"] = postList;
            int pageNum = posts.GetPageNum(uid);
            ViewData["pageNum"] = pageNum;
            ViewData["uid"] = uid;
            ViewData["page"] = page;
            return View();
        }
        public ActionResult Process()
        {
            if (users.GetState() == 0)
            {
                return Redirect("/User/Login");
            }
            string from = Request["from"];
            if (from == "add")
            {
                int uid = users.GetState();
                string title = Request["title"];
                string body = Request["body"];
                string created = Request["created"];
                int pid = posts.Add(uid, title, body, created);
                // jump to the new post
                return Redirect("/Post/Show/" + pid);
            }
            else if (from == "modify")
            {
                int pid = int.Parse(Request["pid"]);
                Posts.Post post = posts.Show(pid);
                if (users.GetState() != post.uid)
                {
                    return Redirect("/User/Login");
                }
                string title = Request["title"];
                string body = Request["body"];
                string created = Request["created"];
                posts.Update(pid, title, body, created);
                return Redirect("/Post/Show/" + pid);
            }
            else if (from == "comment")
            {
                int pid = int.Parse(Request["pid"]);
                int uid = users.GetState();
                string body = Request["body"];
                string created = Request["created"];
                comments.Add(pid, uid, body, created);
                return Redirect("/Post/Show/" + pid);
            }
            return View();
        }
    }
}
