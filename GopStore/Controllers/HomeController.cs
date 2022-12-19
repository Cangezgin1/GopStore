using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GopStore.Controllers
{
    public class HomeController : Controller
    {
        AdminsManager am = new AdminsManager(new EfAdminsDal());

        AdminValidator adminvalidator = new AdminValidator();
        StudentValidator studentvalidator = new StudentValidator();

        StudentsManager sm = new StudentsManager(new EfStudentsDal());

        Context c = new Context();


        #region AdminProfil
        [HttpGet]
        public IActionResult Profil()
        {
            var sessionid = HttpContext.Session.GetInt32("AdminID");
            var values = am.GetById(sessionid);
            return View(values);
        }
        [HttpPost]
        public IActionResult Profil(Admins admins)
        {
            ValidationResult result = adminvalidator.Validate(admins);
            if (result.IsValid)
            {
                am.AdminUpdate(admins);
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        #endregion

        #region Student Listesi
        public IActionResult StudentList()   
        {
            var values = c.Students.Where(x=>x.Status == true).ToList();
            return View(values);
        }
        #endregion

        #region Student Update
        [HttpGet]
        public IActionResult StudentUpdate(int id)
        {
            var values = sm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult StudentUpdate(Students students)
        {
            ValidationResult result = studentvalidator.Validate(students);
            if (result.IsValid)
            {
                sm.StudentUpdate(students);
                return RedirectToAction("StudentList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        #endregion

        #region Student Delete
        public IActionResult StudentDelete(int id)
        {
            var values = sm.GetById(id);
            sm.StudentDelete(values);
            return RedirectToAction("StudentList");
        }
        #endregion

        #region Student Add
        [HttpGet]
        public IActionResult StudentAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentAdd(Students students)
        {
            ValidationResult result = studentvalidator.Validate(students);

            if (result.IsValid)
            {
                sm.StudentAdd(students);
                return RedirectToAction("StudentList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
        #endregion
    }
}
