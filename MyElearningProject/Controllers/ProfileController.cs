using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using MyElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var email = Session["CurrentMail"];
            var values = context.Students.Where(x => x.Email == email).FirstOrDefault();
            return View(values);
        }
        public ActionResult AboutMe()
        {
            var values = Session["CurrentMail"];
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            return View();
        }

        public ActionResult MyCourseList()
        {
            var values = Session["CurrentMail"];
            int id = context.Students.Where(x => x.Email == values).Select(y => y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }
    }
}