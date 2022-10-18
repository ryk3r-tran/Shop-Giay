using KarmaModels;
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
            var customerId = SessionHelper.GetSession().CustomerId;
            var customer = new CustomerModel().getById(customerId);
            ViewData["customer"] = customer;
            return View();
        }

    }
}