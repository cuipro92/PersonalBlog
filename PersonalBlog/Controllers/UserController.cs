using PersonalBlog.DataAccess;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly Role role = new Role();
        private readonly User user = new User();
        // GET: User
        public ActionResult Index()
        {
            return View(user.GetAllData());
        }
        [HttpGet]
        public ActionResult Insert()
        {
            // Create SelectList
            SelectList list = new SelectList(role.GetAllData(), "RoleID", "RoleName");

            // Set into ViewBag
            ViewBag.roleList = list;

            return View();
        }

        [HttpPost]
        public ActionResult Insert(UserModel objUser)
        {
            objUser.DateCreate = Convert.ToDateTime(objUser.DateCreate);
            objUser.DateUpdate = Convert.ToDateTime(objUser.DateUpdate);

            user.InsertUser(objUser);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Create SelectList
            SelectList list = new SelectList(role.GetAllData(), "RoleID", "RoleName");

            // Set into ViewBag
            ViewBag.roleList = list;

            return View(user.GetDataWithID(id));
        }

        [HttpPost]
        public ActionResult Edit(UserModel objUser)
        {
            objUser.DateCreate = Convert.ToDateTime(objUser.DateCreate);
            objUser.DateUpdate = Convert.ToDateTime(objUser.DateUpdate);

            user.UpdateUser(objUser);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                user.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IsLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IsLogin(UserModel objUser)
        {
            bool isLogin = user.IsLogin(objUser.UserName, objUser.Password);
            if(isLogin)
            {
                return RedirectToAction("Index");
            }   else return View();

        }
        
    }
}