using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            TblExperience experience = repo.Find(x => x.Id == id);
            repo.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience experience = repo.Find(x => x.Id == id);
            return View(experience);
        }


        [HttpPost]
        public ActionResult GetExperience(TblExperience p)
        {
            TblExperience experience = repo.Find(x => x.Id == p.Id);
            experience.Title = p.Title;
            experience.Subheading = p.Subheading;
            experience.Description = p.Description;
            experience.Date = p.Date;

            repo.TUpdate(experience);

            return RedirectToAction("Index");
        }
    }
}