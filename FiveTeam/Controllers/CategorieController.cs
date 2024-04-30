using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FiveTeam.Models;


namespace FiveTeam.Controllers
{
    public class CategorieController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

        // GET: Categories
        public ActionResult Categorie()
        {
            return View(db.CategoriesFiveTeams.ToList());
        }
  

    }
}