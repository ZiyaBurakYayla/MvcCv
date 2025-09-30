using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        SkillRepository repo = new SkillRepository();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.Id == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id )
        {
            var skills = repo.Find(x => x.Id == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult GetSkill(TblSkill p)
        {
            var skill = repo.Find(x => x.Id == p.Id);
            skill.Skill = p.Skill;
            skill.Rate = p.Rate;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}