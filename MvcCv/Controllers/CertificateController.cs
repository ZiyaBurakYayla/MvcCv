using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();
        public ActionResult Index()
        {
            var certificates = repo.List();
            return View(certificates);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
            
        [HttpPost]
        public ActionResult AddCertificate(TblCertificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            TblCertificate certificate = repo.Find(x => x.Id == id);
            repo.TDelete(certificate);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            TblCertificate certificate = repo.Find(x => x.Id == id);
            ViewBag.value = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblCertificate p)
        {
            TblCertificate certificate = repo.Find(x => x.Id == p.Id);
            certificate.Description = p.Description;
            certificate.Date = p.Date;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
    }
}