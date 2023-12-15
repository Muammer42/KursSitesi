using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyElearningProject.Controllers
{
    public class InformationAddressController : Controller
    {
        // GET: InformationAddress
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            TempData["Location"] = "İletişim";
            var values = context.InformationAddressess.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInformationAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInformationAddress(InformationAdress ınformationAddress)
        {
            context.InformationAddressess.Add(ınformationAddress);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInformatonAddress(int id)
        {
            var value = context.InformationAddressess.Find(id);
            context.InformationAddressess.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInformationAddress(int id)
        {
            var value = context.InformationAddressess.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInformationAddress(InformationAdress ınformationAddress)
        {
            var value = context.InformationAddressess.Find(ınformationAddress.InformationAddressID);
            value.Title1 = ınformationAddress.Title1;
            value.Address = ınformationAddress.Address;
            value.Title2 = ınformationAddress.Title2;
            value.Phone = ınformationAddress.Phone;
            value.Email = ınformationAddress.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}