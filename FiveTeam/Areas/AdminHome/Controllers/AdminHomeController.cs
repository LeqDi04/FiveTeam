using FiveTeam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace FiveTeam.Areas.AdminHome.Controllers
{
    public class AdminHomeController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            {
                //check code
                if (user.ToLower() == "admin" && password == "123456")
                {
                    Session[user] = "admin";
                    return RedirectToAction("ListProduct", "Product");
                }
                else
                {
                    //thong bao cho nguoi dang nhap sai
                    TempData["error"] = "Tài khoản đăng nhập không chính xác";
                    return View();
                }
            }
        }




    }
}