using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GopStore.Controllers
{
    public class StudentController : Controller
    {
        StudentsManager sm = new StudentsManager(new EfStudentsDal(), new EfStudents_SetlerDal());

        Context c = new Context();

        #region Ana Sayfa

        public IActionResult AnaSayfa()
        {
            var sessionid = HttpContext.Session.GetInt32("StudentID");
            var values = sm.GetById(sessionid);
            return View(values);
        }

        #endregion

        #region Eğitim Seti

        [HttpGet]
        public IActionResult SetList()
        {
            var sessionid = HttpContext.Session.GetInt32("StudentID");

            //var Students_SetlerList = from sS in Students_Setler
            //                          select new {
            //                              İsim = sS.Students.İsim,

            //                          };

            return View();
        }

        #endregion
    }
}
