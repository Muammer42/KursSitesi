using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            TempData["Location"] = "Referanslarım";
            var values = context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            TempData["Location"] = "Referans Ekle";
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //DeleteTestimonial
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //UpdateTestimonial

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonials.Find(testimonial.TestimonialID);
            value.NameSurname = testimonial.NameSurname;
            value.ImageUrl = testimonial.ImageUrl;
            value.Comment = testimonial.Comment;
            value.Title = testimonial.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}