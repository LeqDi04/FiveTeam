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
    public class CategoriesController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

        // GET: Categories
        public ActionResult Categories()
        {
            return View(db.CategoriesFiveTeams.ToList());
        }
        public ActionResult ListCategories()
        {
            return View(db.CategoriesFiveTeams.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoriesFiveTeam categories, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Categories/"), fileName);
                    fileAnh.SaveAs(filePath);
                    categories.Picture = "~/img/Categories/" + fileName;
                }
                db.CategoriesFiveTeams.Add(categories);
                db.SaveChanges();

                return RedirectToAction("ListCategories");
            }
            return View(categories);
        }


        /* sửa sản phẩm*/
        public ActionResult Edit(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

            CategoriesFiveTeam categories = db.CategoriesFiveTeams.Find(id);
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoriesCode,CategoriesName,SellOff,Picture")] CategoriesFiveTeam categories, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Categories/"), fileName);
                    fileAnh.SaveAs(filePath);
                    categories.Picture = "~/img/Categories/" + fileName;
                }

                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListCategories");
            }

            return View(categories);
        }


        /* Xóa sản phẩm*/
        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            var updateModel = db.CategoriesFiveTeams.Find(id);
            db.CategoriesFiveTeams.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("ListCategories");
        }


        // Chi tiết sản phẩm/
        public ActionResult Details(int? id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesFiveTeam categories = db.CategoriesFiveTeams.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }

            return View(categories);
        }

    }
}