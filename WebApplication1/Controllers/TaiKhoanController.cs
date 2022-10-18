using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using KarmaModels;
using WebApplication1.code;

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        
        // [GET] /TaiKhoan/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }


        // [Post] /TaiKhoan/Verify
        [HttpPost]
        public ActionResult verify(LoginModel acc)
        {
            var check_account = new AccountModel().Login(acc.username, acc.password);
            if (check_account != null)
            {
                var accountId = check_account.accountId;
                var customerId = new CustomerModel().getById(accountId).CustomerId;
                SessionHelper.SetSession(new CustomerSession() { CustomerId = customerId});
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("DangNhap", "TaiKhoan");
            }
            
        }
    }
}