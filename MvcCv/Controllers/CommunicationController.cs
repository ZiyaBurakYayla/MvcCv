using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communication
        GenericRepository<TblCommunication> repo = new GenericRepository<TblCommunication>();
        public ActionResult Index()
        {
            var communicationes = repo.List();
            return View(communicationes);
        }
    }
}