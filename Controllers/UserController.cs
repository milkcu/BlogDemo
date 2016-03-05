using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDemo.Models;

namespace BlogDemo.Controllers
{
    public class UserController : Controller
    {
        private Users users;
        public UserController()
        {
            users = new Users();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            if (users.GetState() != 0)
            {
                return Redirect("/");
            }
            return View();
        }
        public ActionResult Login()
        {
            if (users.GetState() != 0)
            {
                return Redirect("/");
            }
            return View();
        }
        public ActionResult Logout()
        {
            users.SetState(0);
            return Redirect("/");
        }
        public ActionResult Process()
        {
            string from = Request["from"];
            string username = Request["username"];
            string password = Request["password"];
            int uid = 0;
            if (from == "register")
            {
                uid = users.Register(username, password);
                if (uid == 0)
                {
                    return Redirect("/User/Register");
                }
                users.SetState(uid);
                return Redirect("/");
            }
            else if (from == "login")
            {
                uid = users.Login(username, password);
                if (uid == 0)
                {
                    return Redirect("/User/Login");
                }
                users.SetState(uid);
                return Redirect("/");
            }
            Session["test"] = "test";
            ViewData["test"] = Session["test"];
            ViewData["uid"] = uid;
            ViewData["username"] = username;
            ViewData["password"] = password;
            ViewData["session"] = users.GetState();
            return View();
        }
        public ActionResult Ajax(string param1)
        {
            string username = param1;
            int isreg = 0;
            if (users.IsRegister(username))
            {
                isreg = 1;
            }
            ViewData["isreg"] = isreg;
            return View();
        }
    }
}
