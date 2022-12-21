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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GopStore.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();


        AdminsManager am = new AdminsManager(new EfAdminsDal());
        StudentsManager sm = new StudentsManager(new EfStudentsDal(),new EfStudents_SetlerDal());
        SetlerManager setm = new SetlerManager(new EfSetlerDal());
        Students_SetlerManager ss = new Students_SetlerManager(new EfStudents_SetlerDal());

        AdminValidator adminvalidator = new AdminValidator();
        StudentValidator studentvalidator = new StudentValidator();
        SetValidator setvalidator = new SetValidator();


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

        #region Student List
        
        public IActionResult StudentList()
        {
            var values = sm.GetList();
            return View(values);
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

        #region Student Update
        [HttpGet]
        public IActionResult StudentUpdate(int id)
        {
            List<SelectListItem> valuesSet = (from x in ss.GetList().Where(x=>x.StudentID==id)
                                              select new SelectListItem
                                              {
                                                  Text = x.SetID.ToString()
                                              }).ToList();

            ViewBag.valuesSet = valuesSet;

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

        #region Set List

        [HttpGet]
        public IActionResult SetList()
        {
            var values = c.Setlers.ToList();
            return View(values);
        }

        #endregion

        #region Set Add

        [HttpGet]
        public IActionResult SetAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetAdd(Setler setler)
        {
            ValidationResult result = setvalidator.Validate(setler);

            if (result.IsValid)
            {
                setm.SetAdd(setler);
                return RedirectToAction("SetList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        #endregion

        #region Set Update

        [HttpGet]
        public IActionResult SetUpdate(int id)
        {
            var values = setm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult SetUpdate(Setler setler)
        {
            ValidationResult result = setvalidator.Validate(setler);
            if (result.IsValid)
            {
                setm.SetUpdate(setler);
                return RedirectToAction("SetList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        #endregion

        #region Set Delete

        public IActionResult SetDelete(int id)
        {
            var values = setm.GetById(id);
            setm.SetDelete(values);
            return RedirectToAction("SetList");
        }

        #endregion
    }
}
