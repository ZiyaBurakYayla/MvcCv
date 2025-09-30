using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education

        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation (TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.Id == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            TblEducation education = repo.Find(x => x.Id == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult GetEducation(TblEducation p)
        {
            TblEducation education = repo.Find(x => x.Id == p.Id);
            education.Title = p.Title;
            education.Subheading1 = p.Subheading1;
            education.Subheading2 = p.Subheading2;
            education.GPA = p.GPA;
            education.Date = p.Date;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }

    }
}