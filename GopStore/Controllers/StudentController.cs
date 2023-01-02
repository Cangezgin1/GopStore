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
        ProductsManager pm = new ProductsManager(new EfProductsDal());


        Context c = new Context();

        #region Ana Sayfa

        public IActionResult AnaSayfa()
        {
            var sessionid = HttpContext.Session.GetInt32("StudentID");
            var values = sm.GetById(sessionid);
            return View(values);
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