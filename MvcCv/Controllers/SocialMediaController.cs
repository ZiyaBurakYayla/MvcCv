using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia (int id )
        {
            var values = repo.Find(x => x.Id == id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
        public ActionResult SituationSocialMedia(int id)
        {
            var values = repo.Find(x => x.Id == id);
            if (values.Situation == false)
                values.Situation = true;
            else
                values.Situation = false;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSocialMedia(int id)
        {
            var values = repo.Find(x => x.Id == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult GetSocialMedia(TblSocialMedia p)
        {
            var values = repo.Find(x => x.Id == p.Id);
            values.Name = p.Name;
            values.Link = p.Link;
            values.Icon = p.Icon;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}