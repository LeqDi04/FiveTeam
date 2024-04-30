using FiveTeam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;



namespace FiveTeam.Controllers
{
    public class BlogController : Controller
    {
        QuanLySanPhamEntities2 db = new QuanLySanPhamEntities2();   
        /*thêm sản phẩm vào giao diện Product*/
        public ActionResult Blog()
        {
            return View(db.BlogsFiveTeams.ToList());
        }


    }
}
