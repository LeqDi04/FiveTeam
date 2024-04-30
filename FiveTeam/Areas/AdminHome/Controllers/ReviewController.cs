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
    public class ReviewController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

        // GET: Review
        public ActionResult Review()
        {
            return View(db.ReviewFiveTeams.ToList());
        }
        public ActionResult ListReview()
        {

            return View(db.ReviewFiveTeams.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReviewFiveTeam review, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Products/"), fileName);
                    fileAnh.SaveAs(filePath);
                    review.Picture = "~/img/Products/" + fileName;
                }
                db.ReviewFiveTeams.Add(review);
                db.SaveChanges();

                return RedirectToAction("ListReview");
            }
            return View(review);
        }



        /* sửa sản phẩm*/
        public ActionResult Edit(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

            ReviewFiveTeam review = db.ReviewFiveTeams.Find(id);
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameReview,ContentReview,Picture,Start")] ReviewFiveTeam review, HttpPostedFileBase fileAnh)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (ModelState.IsValid)
            {
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(fileAnh.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/img/Review/"), fileName);
                    fileAnh.SaveAs(filePath);
                    review.Picture = "~/img/Review/" + fileName;
                }

                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListReview");
            }

            return View(review);
        }


        /* Xóa sản phẩm*/
        public ActionResult Delete(int id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            var updateModel = db.ReviewFiveTeams.Find(id);
            db.ReviewFiveTeams.Remove(updateModel);
            db.SaveChanges();

            return RedirectToAction("ListReview");
        }


        // Chi tiết sản phẩm/
        public ActionResult Details(int? id)
        {
            QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ReviewFiveTeam review = db.ReviewFiveTeams.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }

    }
}