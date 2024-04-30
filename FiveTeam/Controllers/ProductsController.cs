using FiveTeam.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace FiveTeam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Products()
        {
            QuanLySanPhamEntities1 context = new QuanLySanPhamEntities1();
            List<Product> dsCatalog = context.Products.ToList();
            return View(dsCatalog);

        }
    }
}