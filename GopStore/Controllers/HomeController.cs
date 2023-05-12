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
using Microsoft.EntityFrameworkCore;

namespace GopStore.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();

        #region MANAGER'LER

        AdminsManager am = new AdminsManager(new EfAdminsDal());
        StudentsManager sm = new StudentsManager(new EfStudentsDal(), new EfStudents_SetlerDal());
        SetlerManager setm = new SetlerManager(new EfSetlerDal());
        Students_SetlerManager ss = new Students_SetlerManager(new EfStudents_SetlerDal());
        ProductsManager pm = new ProductsManager(new EfProductsDal());
        AdminsManager adminsManager = new AdminsManager(new EfAdminsDal());

        #endregion

        #region VALİDASİONLAR

        AdminValidator adminvalidator = new AdminValidator();
        StudentValidator studentvalidator = new StudentValidator();
        SetValidator setvalidator = new SetValidator();
        ProductsValidator productsvalidator = new ProductsValidator();
        Student_SetValidator student_setlervalidator = new Student_SetValidator();

        #endregion




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

        #region Admin Listeleme

        public IActionResult AdminList()
        {
            var values = adminsManager.GetList();
            return View(values);
        }

        #endregion

        #region Admin Ekleme

        [HttpGet]
        public IActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminAdd(Admins admins)
        {
            ValidationResult result = adminvalidator.Validate(admins);

            if (result.IsValid)
            {
                adminsManager.AdminAdd(admins);
                return RedirectToAction("AdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        #endregion

        #region Admin Silme

        public IActionResult AdminDelete(int id)
        {
            var values = adminsManager.GetById(id);
            adminsManager.AdminDelete(values);
            return RedirectToAction("AdminList");
        }

        #endregion


        #region Student Listeleme

        public IActionResult StudentList(string p)
        {
            var values = sm.GetList();
            if (!string.IsNullOrEmpty(p))
            {
                values = (List<Students>)values.Where(x => x.İsim.Contains(p) || x.Soyisim.Contains(p)).ToList();
            }
            return View(values);
        }

        #endregion

        #region Öğrenciye Set Ekleme

        [HttpGet]
        public IActionResult StudentSetAdd(int id)
        {
            var delist = ss.GetList().Where(x => x.StudentID == id).ToList().Select(x => x.SetID); //öğrenciye ekli olan setıdler bulunuyor.

            List<SelectListItem> valuesSet = (from x in setm.GetList().Where(y => !delist.Contains(y.SetID)) // Öğrenciye kayıtlı olan setıdler gelmiyor.
                                              select new SelectListItem
                                              {
                                                  Text = x.SetAdi,
                                                  Value = x.SetID.ToString()
                                              }).ToList();

            ViewBag.valuesSet = valuesSet;

            List<SelectListItem> valuesStudent = (from x in sm.GetList().Where(x=>x.StudentID==id)
                                              select new SelectListItem
                                              {
                                                  Text = x.StudentID.ToString()
                                              }).ToList();

            ViewBag.valuesStudent = valuesStudent;


            var values = ss.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult StudentSetAdd(Students_Setler students_Setler)
        {
            ss.StudentSetlerAdd(students_Setler);
            return RedirectToAction("StudentList");
        }

        #endregion 

        #region Öğrenci Eğitim Seti Çıkarma

        [HttpGet]
        public IActionResult StudentSetDelete(int id)
        {
            var list = ss.GetList().Where(x => x.StudentID == id).ToList().Select(x => x.SetID); //öğrenciye ekli olan setıdler bulunuyor.

            List<SelectListItem> valuesSet = (from x in setm.GetList().Where(y => list.Contains(y.SetID)) // Öğrenciye kayıtlı olan setıdler geliyor.
                                              select new SelectListItem
                                              {
                                                  Text = x.SetAdi,
                                                  Value = x.SetID.ToString()
                                              }).ToList();

            ViewBag.valuesSet = valuesSet;

            var values = ss.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult StudentSetDelete(Students_Setler students_Setler)
        {
            ss.StudentSetlerDelete(students_Setler);
            return RedirectToAction("StudentList");
        }

        #endregion

        #region Student Add

        [HttpGet]
        public IActionResult StudentAdd()
        {
            //List<SelectListItem> valuesSet = (from x in setm.GetList()
            //                                  select new SelectListItem
            //                                  {
            //                                      Text = x.SetID.ToString()
            //                                  }).ToList();

            //ViewBag.valuesSet = valuesSet;

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
            List<SelectListItem> valuesSet = (from x in ss.GetList().Where(x => x.StudentID == id)
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
            var values = setm.GetList();
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




        #region Ürün List

        public IActionResult ÜrünList()
        {
            var values = pm.GetList();
            return View(values);
        }

        #endregion

        #region Ürün Add

        [HttpGet]
        public IActionResult ÜrünAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ÜrünAdd(Products products)
        {
            ValidationResult result = productsvalidator.Validate(products);

            if (result.IsValid)
            {
                pm.ÜrünAdd(products);
                return RedirectToAction("ÜrünList");
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        #endregion

        #region Ürün Delete

        public IActionResult ÜrünDelete(int id)
        {
            var values = pm.GetById(id);
            pm.ÜrünDelete(values);
            return RedirectToAction("ÜrünList");
        }

        #endregion

        #region Ürün Update

        [HttpGet]
        public IActionResult ÜrünUpdate(int id)
        {
            var values = pm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult ÜrünUpdate(Products products)
        {
            ValidationResult result = productsvalidator.Validate(products);

            if (result.IsValid)
            {
                pm.ÜrünUpdate(products);
                return RedirectToAction("ÜrünList");
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
