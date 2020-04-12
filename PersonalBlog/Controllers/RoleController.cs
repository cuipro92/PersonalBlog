using PersonalBlog.DataAccess;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Controllers
{
    public class RoleController : Controller
    {
        private readonly Role role = new Role();
        // GET: Role
        public ActionResult Index()
        {
            return View(role.GetAllData());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(RoleModel objRole)
        {
            role.InsertRole(objRole);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(role.GetDataWithID(id));
        }

        [HttpPost]
        public ActionResult Edit(RoleModel objRole)
        {
            role.UpdateRole(objRole);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                role.DeleteRole(id);
            }
            return RedirectToAction("Index");
        }
    }
}