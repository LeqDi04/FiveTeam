using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTeam.Models;

namespace FiveTeam.Controllers
{
    public class ReviewwController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
        // GET: Revieww
        public ActionResult Revieww()
        {
            return View(db.ReviewFiveTeams.ToList());
        }
    }
}