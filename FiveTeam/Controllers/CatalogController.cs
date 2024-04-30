using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTeam.Models;
namespace FiveTeam.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Catalog()
        {
            QuanLySanPhamEntities1 context = new QuanLySanPhamEntities1();
            List<Catalog> dsCatalog = context.Catalogs.ToList();
            return View(dsCatalog);

        }

    }
}