using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        GenericRepository<TblHobby> repo = new GenericRepository<TblHobby>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }

        [HttpPost]
        public ActionResult Index(TblHobby p)
        {
            var values = repo.Find(x => x.Id == 1);
            values.Description1 = p.Description1;
            values.Description2 = p.Description2;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}