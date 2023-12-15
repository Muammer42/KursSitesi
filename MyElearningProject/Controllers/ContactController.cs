using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MessageList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }
    }
}