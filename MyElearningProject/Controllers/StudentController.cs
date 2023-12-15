using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            var values = context.Students.Find(id);
            context.Students.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var value = context.Students.Find(student.StudentID);
            value.Name = student.Name;
            value.Surname = student.Surname;
            value.Email = student.Email;
            value.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}