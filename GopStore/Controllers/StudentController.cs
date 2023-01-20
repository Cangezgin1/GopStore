using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GopStore.Controllers
{
    public class StudentController : Controller
    {
        Context c = new Context();

        StudentValidator studentvalidator = new StudentValidator();

        StudentsManager sm = new StudentsManager(new EfStudentsDal(), new EfStudents_SetlerDal());
        ProductsManager pm = new ProductsManager(new EfProductsDal());

        #region Ana Sayfa

        [HttpGet]
        public IActionResult AnaSayfa()
        {
            var sessionid = HttpContext.Session.GetInt32("StudentID");
            var values = sm.GetById(sessionid);
            //ViewBag.Message = " Şifre Başarılı bir şekilde değiştirildi. ";
            return View(values);
        }
        [HttpPost]
        public IActionResult AnaSayfa(Students students)
        {
            sm.StudentUpdate(students);
            return RedirectToAction("SetList");
        }

        #endregion

        #region Eğitim Seti Öğrenciye göre Listelenmesi

        [HttpGet]
        public IActionResult SetList()
        {
            var sessionid = HttpContext.Session.GetInt32("StudentID");

            var values = c.Students.Include(x => x.students_Setlers).ThenInclude(y => y.Setler).Where(x => x.StudentID == sessionid).ToList();
            return View(values);
        }

        #endregion

        #region Ürünlerin Listelenmesi

        public IActionResult ÜrünList()
        {
            var values = pm.GetList();
            return View(values);
        }

        #endregion
    }
}