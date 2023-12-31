﻿using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyElearningProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
        [HttpGet]
        public ActionResult InstructorIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InstructorIndex(Instructor ınstructor)
        {
            var values = context.Instructors.FirstOrDefault(x => x.Email == ınstructor.Email && x.Password == ınstructor.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminIndex(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["CurrentMail"] = values.UserName;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SecmeliGiris()
        {
            return View();
        }
    }
}