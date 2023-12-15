using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            TempData["Location"] = "Kategoriler";
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            TempData["Location"] = "Kategori Ekle";
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            TempData["Location"] = "Kategori Güncelle";
            var value = context.Categories.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}