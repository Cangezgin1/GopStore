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
        StudentLoginManager slm = new StudentLoginManager(new EfStudentDal());


        #region AdminLogin

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admins a)
        {
            var adminkontrol = alm.GetAdmin(a.AdminMail, a.AdminŞifre);

            if (adminkontrol != null)
            {
                HttpContext.Session.SetInt32("AdminID", adminkontrol.AdminID);

                return RedirectToAction("Profil", "Home");
            }
            else
                return RedirectToAction("AdminLogin");
        }

        #endregion

        #region StudentLogin

        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult StudentLogin(Students students)
        {
            var studentkontrol = slm.GetStudent(students.İsim, students.Soyisim, students.TCKimlikNumarasi, students.OkulNumarasi);



            if (studentkontrol != null)
            {
                HttpContext.Session.SetInt32("StudentID", studentkontrol.StudentID);
                return RedirectToAction("AnaSayfa", "Student");
            }
            else
                return RedirectToAction("StudentLogin");
        }

        #endregion
    }
}
