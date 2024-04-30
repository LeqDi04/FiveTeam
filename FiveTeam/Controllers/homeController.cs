using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveTeam.Models;

namespace FiveTeam.Controllers
{
    public class HomeController : Controller
    {
        private QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();

        // GET: home
        public ActionResult Trangchu()
        {
            // Lấy dữ liệu từ database
            var products = db.ProductFiveTeams.ToList();
            var categories = db.CategoriesFiveTeams.ToList();
            var reviews = db.ReviewFiveTeams.ToList();
            var blogs = db.BlogsFiveTeams.ToList();

            // Tạo một ViewModel và truyền dữ liệu vào đó
            var viewModel = new HomePageViewModel
            {
                Products = products,
                Categories = categories,
                Reviews = reviews,
                Blogs = blogs
            };

            return View(viewModel);
        }
        public class HomePageViewModel
        {
            public List<ProductFiveTeam> Products { get; set; }
            public List<CategoriesFiveTeam> Categories { get; set; }
            public List<ReviewFiveTeam> Reviews { get; set; }
            public List<BlogsFiveTeam> Blogs { get; set; }
        }
    }
}
