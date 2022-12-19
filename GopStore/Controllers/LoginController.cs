using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using GopStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace GopStore.Controllers
{
    public class LoginController : Controller
    {
        AdminLoginManager alm = new AdminLoginManager(new EfAdminsDal());

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admins a)
        {
            var adminkontrol = alm.GetAdmin(a.AdminMail,a.AdminŞifre);

            if (adminkontrol != null)
            {
                HttpContext.Session.SetInt32("AdminID", adminkontrol.AdminID);

                return RedirectToAction("Profil", "Home");
            }
            else
                return RedirectToAction("AdminLogin");
        }

    }
}
