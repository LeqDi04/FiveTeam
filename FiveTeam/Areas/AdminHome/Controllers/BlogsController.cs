using FiveTeam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FiveTeam.Areas.AdminHome.Controllers
{
    public class BlogsController : Controller
    {

        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();


        /* in ra danh sách thông tin sản phẩm trong SQL */
        public ActionResult ListBlogs()
        {

            return View(db.BlogsFiveTeams.ToList());
        }

        /* tạo sản phẩm*/
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BlogsFiveTeam blog, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Blogs/"), fileName);
                    fileAnh.SaveAs(filePath);
                    blog.Picture = "~/img/Blogs/" + fileName;
                }

                db.BlogsFiveTeams.Add(blog);
                db.SaveChanges();

                return RedirectToAction("ListBlogs");
            }
            return View(blog);
        }


        /* sửa sản phẩm*/
        public ActionResult Edit(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

            BlogsFiveTeam blog = db.BlogsFiveTeams.Find(id);
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ByUser,Date,Title,ContentTitle,Picture")] BlogsFiveTeam blog, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Blogs/"), fileName);
                    fileAnh.SaveAs(filePath);
                    blog.Picture = "~/img/Blogs/" + fileName;
                }

                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListBlogs");
            }

            return View(blog);
        }


        /* Xóa sản phẩm*/
        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            var updateModel = db.BlogsFiveTeams.Find(id);
            db.BlogsFiveTeams.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("ListBlogs");
        }


        // Chi tiết sản phẩm/
        public ActionResult Details(int? id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogsFiveTeam blog = db.BlogsFiveTeams.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }
    }
}