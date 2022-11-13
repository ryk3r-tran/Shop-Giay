using KarmaModels;
using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.code;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var data = sanpham.GetAll();          
            return View(data);
        }

    }
}