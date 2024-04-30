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
    public class ProductController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

        public ActionResult Product()
        {
            return View(db.ProductFiveTeams.ToList());
        }
        public ActionResult ListProduct()
        {

            return View(db.ProductFiveTeams.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductFiveTeam product, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Products/"), fileName);
                    fileAnh.SaveAs(filePath);
                    product.Picture = "~/img/Products/" + fileName;
                }
                db.ProductFiveTeams.Add(product);
                db.SaveChanges();

                return RedirectToAction("ListProduct");
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

            ProductFiveTeam product = db.ProductFiveTeams.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductCode,ProductName,Prince,Picture")] ProductFiveTeam product, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Products/"), fileName);
                    fileAnh.SaveAs(filePath);
                    product.Picture = "~/img/Products/" + fileName;
                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListProduct");
            }

            return View(product);
        }


        /* Xóa sản phẩm*/
        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            var updateModel = db.ProductFiveTeams.Find(id);
            db.ProductFiveTeams.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("ListProduct");
        }


        // Chi tiết sản phẩm/
        public ActionResult Details(int? id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductFiveTeam product = db.ProductFiveTeams.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}