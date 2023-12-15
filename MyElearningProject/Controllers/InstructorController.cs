using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            TempData["Location"] = "Eğitmenler";
            var values = context.Instructors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInstructor(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInstructor(int id)
        {
            var value = context.Instructors.Find(id);
            context.Instructors.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateInstructor(int id)
        {
            var value = context.Instructors.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateInstructor(Instructor instructor)
        {
            TempData["Location"] = "Eğitmenleri Güncelle";
            var value = context.Instructors.Find(instructor.InstructorID);
            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.ImageUrl = instructor.ImageUrl;
            value.Title = instructor.Title;
            value.CoverImage = instructor.CoverImage;
            value.Email = instructor.Email;
            value.Password = instructor.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}