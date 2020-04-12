using PersonalBlog.DataAccess;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Category cate = new Category();
        private readonly User user = new User();
        // GET: Category
        public ActionResult Index()
        {
            return View(cate.GetAllData());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            // Create SelectList
            SelectList list = new SelectList(user.GetAllData(), "UserID", "UserName");

            // Set into ViewBag
            ViewBag.userList = list;

            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryModel objCategory)
        {
            objCategory.DateCreate = Convert.ToDateTime(objCategory.DateCreate);
            objCategory.DateUpdate = Convert.ToDateTime(objCategory.DateUpdate);

            
            cate.InsertCategory(objCategory);


            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Create SelectList
            SelectList list = new SelectList(user.GetAllData(), "UserID", "UserName");

            // Set into ViewBag
            ViewBag.userList = list;

            return View(cate.GetDataWithID(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel objCategory)
        {
            objCategory.DateCreate = Convert.ToDateTime(objCategory.DateCreate);
            objCategory.DateUpdate = Convert.ToDateTime(objCategory.DateUpdate);

            cate.UpdateCategory(objCategory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                cate.DeleteCategory(id);
            }
            return RedirectToAction("Index");
        }
    }
}