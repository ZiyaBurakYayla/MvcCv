using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var expreriences = db.TblExperience.ToList();
            return PartialView(expreriences);
        }

        public PartialViewResult Education()
        {
            var educations = db.TblEducation.ToList();
            return PartialView(educations);
        }

        public PartialViewResult Skill()
        {
            var skills = db.TblSkill.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Hobby()
        {
            var hobbies = db.TblHobby.ToList();
            return PartialView(hobbies);
        }

        public PartialViewResult Certificate()
        {
            var certificates = db.TblCertificate.ToList();
            return PartialView(certificates);
        }

        [HttpGet]
        public PartialViewResult Communication()
        {
            //var communications = db.TblCommunication.ToList();
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Communication(TblCommunication p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCommunication.Add(p);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SocialMedia()
        {
            var SocialMedias = db.TblSocialMedia.ToList();
            return PartialView(SocialMedias);
        }
    }
}