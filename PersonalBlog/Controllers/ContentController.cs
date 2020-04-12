using PersonalBlog.DataAccess;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBlog.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content content = new Content();
        private readonly Category cate = new Category();
        private readonly User user = new User();
        // GET: Content
        public ActionResult Index()
        {
            return View(content.GetAllData());
        }

        [HttpGet]
        public ActionResult Insert()
        {
            // Create SelectList
            SelectList list = new SelectList(user.GetAllData(), "UserID", "UserName");
            SelectList listCate = new SelectList(cate.GetAllData(), "CategoryID", "CategoryName");

            // Set into ViewBag
            ViewBag.userList = list;
            ViewBag.listCategory = listCate;

            return View();
        }

        [HttpPost]
        public ActionResult Insert(ContentModel objContent)
        {
            objContent.DateCreate = Convert.ToDateTime(objContent.DateCreate);
            objContent.DateUpdate = Convert.ToDateTime(objContent.DateUpdate);

            content.InsertContent(objContent);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            // Create SelectList
            SelectList list = new SelectList(user.GetAllData(), "UserID", "UserName");
            SelectList listCate = new SelectList(cate.GetAllData(), "CategoryID", "CategoryName");

            // Set into ViewBag
            ViewBag.userList = list;
            ViewBag.listCategory = listCate;

            return View(content.GetDataWithID(id));
        }

        [HttpPost]
        public ActionResult Edit(ContentModel objContent)
        {
            objContent.DateCreate = Convert.ToDateTime(objContent.DateCreate);
            objContent.DateUpdate = Convert.ToDateTime(objContent.DateUpdate);

            content.UpdateContent(objContent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                content.DeleteContent(id);
            }
            return RedirectToAction("Index");
        }
    }
}