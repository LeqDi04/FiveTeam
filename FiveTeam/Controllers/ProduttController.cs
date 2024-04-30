using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTeam.Models;

namespace FiveTeam.Controllers
{
    public class ProduttController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();
        // GET: Produtt
        public ActionResult Produtt()
        {
            return View(db.ProductFiveTeams.ToList());
        }
    }
}