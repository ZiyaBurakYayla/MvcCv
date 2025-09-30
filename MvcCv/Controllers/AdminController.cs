using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin admin = repo.Find(x => x.Id == id);
            repo.TDelete(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            TblAdmin admin = repo.Find(x => x.Id == id);
            return View(admin);
        }


        [HttpPost]
        public ActionResult GetAdmin(TblAdmin p)
        {
            TblAdmin admin = repo.Find(x => x.Id == p.Id);
            admin.Username = p.Username;
            admin.Sifre = p.Sifre;
            repo.TUpdate(admin);

            return RedirectToAction("Index");
        }
    }
}