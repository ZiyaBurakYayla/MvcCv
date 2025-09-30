using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var Abouts = repo.List();
            return View(Abouts);
        }

        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var values = repo.Find(x => x.Id == 1);
            values.Name = p.Name;
            values.Surname = p.Surname;
            values.Adress = p.Adress;
            values.PhoneNo = p.PhoneNo;
            values.Mail = p.Mail;
            values.Description = p.Description;
            values.Image = p.Image;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}